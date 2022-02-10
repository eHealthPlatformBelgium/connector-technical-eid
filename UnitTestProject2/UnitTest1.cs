using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Security.Cryptography;
using System;
using System.Text;
using connector_technical_eid;


namespace UnitTestProject2
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void Test_signature_RSA()
        {
            Console.WriteLine("start test");
            var proxy = new BeidPKCS11Proxy();
            SHA256 sha256 = new SHA256CryptoServiceProvider();
            byte[] hash = sha256.ComputeHash(Encoding.ASCII.GetBytes("data"));
            byte[] signeddata = proxy.SignData(hash, "SHA-256", Alias.AUTHENTICATION);
            Assert.IsNotNull(signeddata);
            Console.WriteLine("signed data: " + BitConverter.ToString(signeddata));
            Console.WriteLine("test ended");
        }

        [TestMethod]
        public void Test_signature_EC()
        {
            Console.WriteLine("start test");
            var proxy = new BeidPKCS11Proxy();
            SHA256 sha256 = new SHA256CryptoServiceProvider();
            byte[] hash = sha256.ComputeHash(Encoding.ASCII.GetBytes("data"));
            byte[] signeddata = proxy.SignData(hash, "SHA-256", Alias.AUTHENTICATION);
            Assert.IsNotNull(signeddata);
            Console.WriteLine("signed data: " + BitConverter.ToString(signeddata));
            Console.WriteLine("test ended");
        }

        [TestMethod]
        public void Test_getAlgorithm()
        {
            Console.WriteLine("start test");
            var proxy = new BeidPKCS11Proxy();
            var algo = proxy.GetAlgorithm(Alias.AUTHENTICATION);
            Console.WriteLine("Algorithm: {0}", algo.ToString());
            Console.WriteLine("test ended");
        }
    }
}
