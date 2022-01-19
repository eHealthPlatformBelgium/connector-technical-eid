using connector_technical_eid.domain;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;

namespace connector_technical_eid
{
    public interface IBeIdProxy
    {
        /**
        * <summary>
        * Method used for reading the content of the connected eID
        * 
        * <returns>BeIDInfo of the connector eID</returns>
        * 
        * </summary>
        */
        BeIDInfo Read();

        /**
        * <summary>
        * Method used for signing a already calculated digest.
        * 
        * <param>The hash to sign</param>
        * <param>Hashing algorithm  used to calculate the digest</param>
        * <param>alias</param>
        * <returns>The signature for the specified data.</returns>
        * 
        * </summary>
        */
        byte[] SignData(byte[] buffer, string digestAlgo, string alias);

        /**
        * <summary>
        * Method for obtaining all the aliases that are supported by the distributed keystore.
        * 
        * <return>The list of alias that can be used to interact with</return>
        * 
        * </summary>
        */
        ISet<string> GetAliases();

        /**
         * <summary>
         * Returns the standard algorithm name for this key.
         * 
         * <param>alias</param>
         * <returns>the name of the algorithm associated with this key.</returns>
         * 
         * </summary>
        */
        Algorithm GetAlgorithm(string alias);

        /**
        *<summary>
        *Method for obtaining the certificate chain based on the distributed keystore and the alias. 
        * - The first entry of the list is the actual certificate. 
        * - The second entry the CA of your certificate. 
        * - The third entry should be CA of the CA of you certificate.
        * - ...
        * 
        * <param>alias</param>
        * <returns>List that contains the certificate chain</returns>
        * 
        * </summary>
        */
        IList<X509Certificate> GetCertificateChain(string alias);

    }
}