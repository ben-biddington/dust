using System;
using System.IO;
using System.Security.Cryptography;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using Dust.Core;
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
            return GenerateSignature(signatureBaseString).Tap(it =>
            {
                Console.WriteLine("VALIDATES => {0}", ValidateSignature(signatureBaseString, it));
            });
        }

        string GenerateSignature(string baseString)
        {
            SHA1CryptoServiceProvider sha1 = GenerateHash(baseString);

            var formatter = new RSAPKCS1SignatureFormatter(_certificate.PrivateKey);
            formatter.SetHashAlgorithm("MD5");

            byte[] signature = formatter.CreateSignature(sha1);

            return Convert.ToBase64String(signature);
        }

        public bool ValidateSignature(string baseString, string signature)
        {
            SHA1CryptoServiceProvider sha1 = GenerateHash(baseString);

            var deformatter = new RSAPKCS1SignatureDeformatter(_certificate.PrivateKey);
            deformatter.SetHashAlgorithm("MD5");

            return deformatter.VerifySignature(sha1, Convert.FromBase64String(signature));
        }

        SHA1CryptoServiceProvider GenerateHash(string signtureBaseString)
        {
            var sha1 = new SHA1CryptoServiceProvider();

            byte[] dataBuffer = Encoding.ASCII.GetBytes(signtureBaseString);

            var cs = new CryptoStream(Stream.Null, sha1, CryptoStreamMode.Write);
            cs.Write(dataBuffer, 0, dataBuffer.Length);
            cs.Close();
            return sha1;
        }
    }
}