using System;
using System.IO;
using System.Security.Cryptography;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using Dust.Lang;

namespace Dust
{
    public class RsaSha1
    {
        private readonly X509Certificate2 _certificate;

        public RsaSha1(X509Certificate2 certificate)
        {
            _certificate = certificate;
        }

        public string Sign(string signatureBaseString)
        {
            return SignCore(signatureBaseString);
        }

        string SignCore(string baseString)
        {
            using (var hash = Hash(baseString))
            {
                return Base64Encode(Sign(hash));
            }
        }

        private static string Base64Encode(byte[] signature)
        {
            return Convert.ToBase64String(signature);
        }

        private byte[] Sign(SHA1CryptoServiceProvider hash)
        {
            var formatter = new RSAPKCS1SignatureFormatter(_certificate.PrivateKey).
                Tap(it => it.SetHashAlgorithm("MD5"));

            return formatter.CreateSignature(hash);
        }

        SHA1CryptoServiceProvider Hash(string signatureBaseString)
        {
            var sha1 = new SHA1CryptoServiceProvider();

            var bytes = Encoding.ASCII.GetBytes(signatureBaseString);

            using (var cs = new CryptoStream(Stream.Null, sha1, CryptoStreamMode.Write))
            {
                cs.Write(bytes, 0, bytes.Length);
                cs.Close();
            }

            return sha1;
        }
    }
}