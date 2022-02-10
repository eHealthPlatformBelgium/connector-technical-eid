using System;
using System.Collections.Generic;
using System.IO;
using System.Numerics;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using connector_technical_eid.domain;
using Net.Sf.Pkcs11;
using Net.Sf.Pkcs11.Objects;
using Net.Sf.Pkcs11.Wrapper;

namespace connector_technical_eid
{

    public class BeidPKCS11Proxy : IBeIdProxy
    {
        internal class BeIDModule : IDisposable
        {

            private Module _m;
            private Session _session;
            private string _mFileName;

            public BeIDModule(string mFileName = "beidpkcs11.dll")
            {
                this._mFileName = mFileName;
            }

            public void Dispose()
            {
                if (_m != null) _m.Dispose();
                _session = null;
            }

            private void initModule()
            {

                if (_m == null) _m = Module.GetInstance(_mFileName);
            }

            public Session GetSession(int slot = 0)
            {
                initModule();
                var slotList = _m.GetSlotList(true);
                if (slotList.Length == 0) throw new ArgumentException("No eID present!");
                if (_session == null)
                {
                    _session = slotList[slot].Token.OpenSession(true);
                }
                return _session;

            }

            public P11Object FindObject(string fileName, CKO objectType, int slot = 0)
            {
                var session = GetSession(slot);
                var classAttribute = new ObjectClassAttribute(objectType);
                var keyLabelAttribute = new ByteArrayAttribute(CKA.LABEL) { Value = Encoding.UTF8.GetBytes(fileName) };
                session.FindObjectsInit(classAttribute, keyLabelAttribute);

                var foundObjects = session.FindObjects(1);
                session.FindObjectsFinal();
                P11Object result = null;
                if (foundObjects.Length >= 1) result = foundObjects[0];
                return result;
            }
        }

        internal class BeIdInfoGenerator
        {
            public static BeIDInfo Generate()
            {
                var info = new BeIDInfo();

            using (var m = new BeIDModule())
            {
                var identityFile = m.FindObject("DATA_FILE", CKO.DATA) as Data;
                info.identity = ParseIdentity(identityFile);

                var addressFile = m.FindObject("ADDRESS_FILE", CKO.DATA) as Data;
                info.address = ParseAddress(addressFile);

                var photoFile = m.FindObject("PHOTO_FILE", CKO.DATA) as Data;
                if (photoFile != null)
                {
                    info.photo = photoFile.Value.Value;
                }

            }

            return info;
        }

        private static Identity ParseIdentity(Data data)
        {
            var identity = new Identity();
            var d = data.Value.Value.Parse();
            identity.cardNumber = d[0x01].ToStr();
            identity.chipNumber= (d[0x02].ToHex());
            identity.cardValidityDateBegin=(d[0x03].ToDate());
            identity.cardValidityDateEnd=(d[0x04].ToDate());
            identity.cardDeliveryMunicipality=(d[0x05].ToStr());
            identity.nationalNumber=(d[0x06].ToStr());
            identity.name=(d[0x07].ToStr());
            identity.firstName=(d[0x08].ToStr());
            identity.middleName=(d[0x09].ToStr());
            identity.nationality=(d[0x0A].ToStr());
            identity.placeOfBirth=(d[0x0B].ToStr());
            identity.dateOfBirth=(d[0x0C].ToBirthDate());
            identity.gender=(d[0x0D].ToGender());
            identity.nobleCondition=(d[0x0E].ToStr());
            identity.documentType=(d[0x0F].ToDocType());
            identity.specialStatus=(d[0x10].ToSpec());
            //   identity.setSpecialOrganisation(d[0].ToSpecialOrganisation());
            return identity;
        }

        private static Address ParseAddress(Data data)
        {
            var d = data.Value.Value.Parse();
            var address = new Address();
            address.streetAndNumber=(d[0x01].ToString());
            address.zip=(d[0x02].ToString());
            address.municipality=(d[0x03].ToString());
            return address;
        }
    }

    public Algorithm GetAlgorithm(Alias alias)
        {
            using (var m = new BeIDModule())
            {
                byte[] cert = GetCertificate(UppercaseFirst(alias), m).GetRawCertData();
                X509Certificate2 x509 = new X509Certificate2(cert);
                if (x509.GetRSAPublicKey() != null) return Algorithm.RSA;
                if (x509.GetECDsaPublicKey() != null) return Algorithm.ECC;
                throw new Exception("Unsupported Public key");
            }
        }

        public ISet<Alias> GetAliases()
        {
            ISet<Alias> aliases = new HashSet<Alias>();
            aliases.Add(Alias.AUTHENTICATION);
            aliases.Add(Alias.SIGNATURE);
            return aliases;
        }

        public IList<X509Certificate> GetCertificateChain(Alias alias)
        {
            using (var m = new BeIDModule())
            {
                // LOG.debug("Lookup CertificateChain for alias [{}]", alias);
                IList<X509Certificate> result = new X509Certificate[3];
                result.Add(GetCertificate(UppercaseFirst(alias), m));
                result.Add(GetCertificate("CA", m));
                result.Add(GetCertificate("Root", m));
                //LOG.debug("CertificateChain reconstructed.", alias);
                return result;
            }
        }

        private X509Certificate GetCertificate(string alias, BeIDModule m)
        {
            var cert = m.FindObject(alias, CKO.CERTIFICATE) as X509PublicKeyCertificate;
            return new X509Certificate(cert.Value.Value);

        }

        public BeIDInfo Read()
        {
            return BeIdInfoGenerator.Generate();
        }

        public byte[] SignData(byte[] digestValue, string digestAlgo, Alias alias)
        {
            byte[] result = null;
            byte[] encryptedData = null;
            
            
            // LOG.debug("Signing started");
            using (var m = new BeIDModule())
            {
                //TODO FIXME alias to String convertion
                var privateKey = m.FindObject(UppercaseFirst(alias), CKO.PRIVATE_KEY) as PrivateKey;

                if (privateKey != null)
                {
                    var session = m.GetSession();
                    switch (privateKey.KeyType.KeyType)
                    {
                        case CKK.EC:
                            session.SignInit(new Mechanism(CKM.ECDSA), (PrivateKey)privateKey);
                            break;
                        case CKK.RSA:
                            session.SignInit(new Mechanism(CKM.RSA_PKCS), privateKey);
                            break;
                        default:
                            throw new ArgumentException("Unsupported Digest Algorithm: " + digestAlgo);
                    }
                    var data = DataToSign(digestValue, digestAlgo, privateKey);
                    encryptedData = session.Sign(digestValue);
                    result = ToDerSignature(encryptedData, privateKey);
                }
            }
            // LOG.debug("Signing done.");
            return result;
        }

        private static string UppercaseFirst(Alias alias)
        {
            string s = alias.ToString();
            if (string.IsNullOrEmpty(s)) return string.Empty;
            return char.ToUpper(s[0]) + s.Substring(1).ToLower();
        }

        private static byte[] ToDerSignature(byte[] signedData, Key privateKey)
        {
            return privateKey.KeyType.KeyType == CKK.EC ? ToDerSignature(signedData) : signedData;
        }

        private static byte[] DataToSign(byte[] digestValue, string digestAlgo, Key privateKey)
        {
            using (var stream = new MemoryStream())
            {
                using (var writer = new BinaryWriter(stream))
                {
                    if (privateKey.KeyType.KeyType == CKK.RSA)
                        writer.Write(GetBeIdDigest(digestAlgo).getPrefix(digestValue.Length));
                    writer.Write(digestValue);
                }

                return stream.ToArray();
            }
        }

        private static BeIDDigest GetBeIdDigest(string digestAlgo)
        {
            foreach (var beIdDigest in BeIDDigest.VALUES)
                if (beIdDigest.getStandardName().Equals(digestAlgo))
                    return beIdDigest;
            throw new ArgumentException("Unsupported Digest Algorithm: " + digestAlgo);
        }

        public static byte[] ToDerSignature(byte[] rawSign)
        {
            var len = rawSign.Length / 2;

            var rawR = new byte[len];
            var rawS = new byte[len];
            Array.Copy(rawSign, 0, rawR, 0, len);
            Array.Copy(rawSign, len, rawS, 0, len);

            var bigIntR = new BigInteger(rawR);
            var bigIntS = new BigInteger(rawS);

            var r = bigIntR.ToByteArray();
            var s = bigIntS.ToByteArray();

            var der = new byte[r.Length + s.Length + 6];
            der[0] = 0x30;
            der[1] = (byte)(r.Length + s.Length + 4);
            der[2] = 0x02;
            der[3] = (byte)r.Length;
            Array.Copy(r, 0, der, 4, r.Length);
            der[4 + r.Length] = 0x02;
            der[5 + r.Length] = (byte)s.Length;
            Array.Copy(s, 0, der, 6 + r.Length, s.Length);

            return der;
        }
    }
}
