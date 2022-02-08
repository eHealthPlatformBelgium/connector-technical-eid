using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace connector_technical_eid.domain
{
    internal class BeIDDigest
    {
        internal static BeIDDigest PLAIN_TEXT = new BeIDDigest(nameof(PLAIN_TEXT), 0, new byte[15]
    {
      (byte) 48,
      byte.MaxValue,
      (byte) 48,
      (byte) 9,
      (byte) 6,
      (byte) 7,
      (byte) 96,
      (byte) 56,
      (byte) 1,
      (byte) 2,
      (byte) 1,
      (byte) 3,
      (byte) 1,
      (byte) 4,
      byte.MaxValue
    });
        internal static BeIDDigest SHA_1 = new BeIDDigest(nameof(SHA_1), 1, new byte[15]
        {
      (byte) 48,
      (byte) 33,
      (byte) 48,
      (byte) 9,
      (byte) 6,
      (byte) 5,
      (byte) 43,
      (byte) 14,
      (byte) 3,
      (byte) 2,
      (byte) 26,
      (byte) 5,
      (byte) 0,
      (byte) 4,
      (byte) 20
        });
        internal static BeIDDigest SHA_224 = new BeIDDigest(nameof(SHA_224), 2, new byte[19]
        {
      (byte) 48,
      (byte) 45,
      (byte) 48,
      (byte) 13,
      (byte) 6,
      (byte) 9,
      (byte) 96,
      (byte) 134,
      (byte) 72,
      (byte) 1,
      (byte) 101,
      (byte) 3,
      (byte) 4,
      (byte) 2,
      (byte) 4,
      (byte) 5,
      (byte) 0,
      (byte) 4,
      (byte) 28
        });
        internal static BeIDDigest SHA_256 = new BeIDDigest(nameof(SHA_256), 3, new byte[19]
        {
      (byte) 48,
      (byte) 49,
      (byte) 48,
      (byte) 13,
      (byte) 6,
      (byte) 9,
      (byte) 96,
      (byte) 134,
      (byte) 72,
      (byte) 1,
      (byte) 101,
      (byte) 3,
      (byte) 4,
      (byte) 2,
      (byte) 1,
      (byte) 5,
      (byte) 0,
      (byte) 4,
      (byte) 32
        });
        internal static BeIDDigest SHA_384 = new BeIDDigest(nameof(SHA_384), 4, new byte[19]
        {
      (byte) 48,
      (byte) 65,
      (byte) 48,
      (byte) 13,
      (byte) 6,
      (byte) 9,
      (byte) 96,
      (byte) 134,
      (byte) 72,
      (byte) 1,
      (byte) 101,
      (byte) 3,
      (byte) 4,
      (byte) 2,
      (byte) 2,
      (byte) 5,
      (byte) 0,
      (byte) 4,
      (byte) 48
        });
        internal static BeIDDigest SHA_512 = new BeIDDigest(nameof(SHA_512), 5, new byte[19]
        {
      (byte) 48,
      (byte) 81,
      (byte) 48,
      (byte) 13,
      (byte) 6,
      (byte) 9,
      (byte) 96,
      (byte) 134,
      (byte) 72,
      (byte) 1,
      (byte) 101,
      (byte) 3,
      (byte) 4,
      (byte) 2,
      (byte) 3,
      (byte) 5,
      (byte) 0,
      (byte) 4,
      (byte) 64
        });
        internal static BeIDDigest RIPEMD_128 = new BeIDDigest(nameof(RIPEMD_128), 6, new byte[15]
        {
      (byte) 48,
      (byte) 29,
      (byte) 48,
      (byte) 9,
      (byte) 6,
      (byte) 5,
      (byte) 43,
      (byte) 36,
      (byte) 3,
      (byte) 2,
      (byte) 2,
      (byte) 5,
      (byte) 0,
      (byte) 4,
      (byte) 16
        });
        internal static BeIDDigest RIPEMD_160 = new BeIDDigest(nameof(RIPEMD_160), 7, new byte[15]
        {
      (byte) 48,
      (byte) 33,
      (byte) 48,
      (byte) 9,
      (byte) 6,
      (byte) 5,
      (byte) 43,
      (byte) 36,
      (byte) 3,
      (byte) 2,
      (byte) 1,
      (byte) 5,
      (byte) 0,
      (byte) 4,
      (byte) 20
        });
        internal static BeIDDigest RIPEMD_256 = new BeIDDigest(nameof(RIPEMD_256), 8, new byte[15]
        {
      (byte) 48,
      (byte) 45,
      (byte) 48,
      (byte) 9,
      (byte) 6,
      (byte) 5,
      (byte) 43,
      (byte) 36,
      (byte) 3,
      (byte) 2,
      (byte) 3,
      (byte) 5,
      (byte) 0,
      (byte) 4,
      (byte) 32
        });
        internal static BeIDDigest SHA3_256 = new BeIDDigest(nameof(SHA3_256), 9, new byte[19]
        {
      (byte) 48,
      (byte) 49,
      (byte) 48,
      (byte) 13,
      (byte) 6,
      (byte) 9,
      (byte) 96,
      (byte) 134,
      (byte) 72,
      (byte) 1,
      (byte) 101,
      (byte) 3,
      (byte) 4,
      (byte) 2,
      (byte) 8,
      (byte) 5,
      (byte) 0,
      (byte) 4,
      (byte) 32
        });
        internal static BeIDDigest SHA3_384 = new BeIDDigest(nameof(SHA3_384), 10, new byte[19]
        {
      (byte) 48,
      (byte) 65,
      (byte) 48,
      (byte) 13,
      (byte) 6,
      (byte) 9,
      (byte) 96,
      (byte) 134,
      (byte) 72,
      (byte) 1,
      (byte) 101,
      (byte) 3,
      (byte) 4,
      (byte) 2,
      (byte) 9,
      (byte) 5,
      (byte) 0,
      (byte) 4,
      (byte) 48
        });
        internal static BeIDDigest SHA3_512 = new BeIDDigest(nameof(SHA3_512), 11, new byte[19]
        {
      (byte) 48,
      (byte) 81,
      (byte) 48,
      (byte) 13,
      (byte) 6,
      (byte) 9,
      (byte) 96,
      (byte) 134,
      (byte) 72,
      (byte) 1,
      (byte) 101,
      (byte) 3,
      (byte) 4,
      (byte) 2,
      (byte) 10,
      (byte) 5,
      (byte) 0,
      (byte) 4,
      (byte) 64
        });
        internal static BeIDDigest SHA_1_PSS = new BeIDDigest(nameof(SHA_1_PSS), 12, new byte[0], 16);
        internal static BeIDDigest SHA_256_PSS = new BeIDDigest(nameof(SHA_256_PSS), 13, new byte[0], 32);
        internal static BeIDDigest ECDSA_SHA_2_256 = new BeIDDigest(nameof(ECDSA_SHA_2_256), 14, new byte[0], 1, true);
        internal static BeIDDigest ECDSA_SHA_2_384 = new BeIDDigest(nameof(ECDSA_SHA_2_384), 15, new byte[0], 2, true);
        internal static BeIDDigest ECDSA_SHA_2_512 = new BeIDDigest(nameof(ECDSA_SHA_2_512), 16, new byte[0], 4, true);
        internal static BeIDDigest ECDSA_SHA_3_256 = new BeIDDigest(nameof(ECDSA_SHA_3_256), 17, new byte[0], 8, true);
        internal static BeIDDigest ECDSA_SHA_3_384 = new BeIDDigest(nameof(ECDSA_SHA_3_384), 18, new byte[0], 16, true);
        internal static BeIDDigest ECDSA_SHA_3_512 = new BeIDDigest(nameof(ECDSA_SHA_3_512), 19, new byte[0], 32, true);
        internal static BeIDDigest NONE = new BeIDDigest(nameof(NONE), 20, new byte[0]);
        internal static BeIDDigest ECDSA_NONE = new BeIDDigest(nameof(ECDSA_NONE), 21, new byte[0], 64, true);

        internal static BeIDDigest[] VALUES = new BeIDDigest[22]
        {
            PLAIN_TEXT,     SHA_1,     SHA_224,     SHA_256,     SHA_384,     SHA_512,     RIPEMD_128,     RIPEMD_160,     RIPEMD_256,     SHA3_256,     SHA3_384,     SHA3_512,     SHA_1_PSS,    SHA_256_PSS,     ECDSA_SHA_2_256,     ECDSA_SHA_2_384,     ECDSA_SHA_2_512,     ECDSA_SHA_3_256,     ECDSA_SHA_3_384,     ECDSA_SHA_3_512,     NONE,     ECDSA_NONE
         };

        private string name;
        private byte[] prefix;
        private int algorithmReference;
        private bool ec;
        BeIDDigest(String name, int i, byte[] prefix)
        {
            this.prefix = prefix;
            this.name = name;
            this.prefix = (byte[])prefix.Clone();
        }
        BeIDDigest(String name, int i, byte[] prefix, int algorithmReference, bool ec)
        {
            this.name = name;
            this.prefix = (byte[])prefix.Clone();
            this.algorithmReference = algorithmReference;
            this.ec = ec;
        }

        BeIDDigest(String name, int i, byte[] prefix, int algorithmReference)
        {
            this.name = name;
            this.prefix = (byte[])prefix.Clone();
            this.algorithmReference = algorithmReference;
        }

        public byte[] getPrefix(int valueLength)
        {
            if (!this.Equals(PLAIN_TEXT))               
                return this.prefix;
            byte[] numArray = new byte[this.prefix.Length];
            Array.Copy(this.prefix, numArray, this.prefix.Length);
            numArray[1] = (byte)(valueLength + 13);
            numArray[14] = (byte)valueLength;
            return numArray;
        }

        public String getStandardName()
        {
            return this.name.Replace('_', '-');
        }


    }
}
