using Org.BouncyCastle.Crypto;
using Org.BouncyCastle.Crypto.Parameters;
using Org.BouncyCastle.OpenSsl;
using Org.BouncyCastle.Security;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace RSAEncriptacionService.Helpers
{
    public class RSAHelper
    {
        public static string Decrypt(string encrypted)
        {
            RSACryptoServiceProvider PrivateKey = GetPrivateKeyFromPemFile();
            byte[] decryptedBytes = PrivateKey.Decrypt(Convert.FromBase64String(encrypted), false);
            string decripted = Encoding.UTF8.GetString(decryptedBytes, 0, decryptedBytes.Length);
            return decripted;
        }

        private static RSACryptoServiceProvider GetPrivateKeyFromPemFile()
        {
            string privateKeyName = "private.key.pem";
            string privateKeyPath = Path.Combine(".", privateKeyName);
            string privateKey = File.ReadAllText(privateKeyPath);
            using (TextReader privateKeyStringReader = new StringReader(privateKey))
            {
                AsymmetricCipherKeyPair pemReader = (AsymmetricCipherKeyPair)new PemReader(privateKeyStringReader).ReadObject();
                RSAParameters rsaPrivateCrtKeyParameters = DotNetUtilities.ToRSAParameters((RsaPrivateCrtKeyParameters)pemReader.Private);
                RSACryptoServiceProvider rsaCryptoServiceProvider = new RSACryptoServiceProvider();
                rsaCryptoServiceProvider.ImportParameters(rsaPrivateCrtKeyParameters);
                return rsaCryptoServiceProvider;
            }
        }

    }
}
