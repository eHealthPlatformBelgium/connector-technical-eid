using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using connector_technical_eid;


namespace UnitTestProject2
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void Test_signature()
        {
            Console.WriteLine("start test");
            var proxy = new BeidPKCS11Proxy();
            byte[] testdata = new byte[] { 0, 1, 2, 3, 4, 5, 6, 7, 8 };
            byte[] signeddata = proxy.SignData(testdata, "SHA-256", Alias.AUTHENTICATION);
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
