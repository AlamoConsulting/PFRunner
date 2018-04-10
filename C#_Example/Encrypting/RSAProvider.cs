using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Encrypting
{
    public class RSAProvider
    {
        public RSACryptoServiceProvider RSAService { get; set; }

        public RSAProvider()
        {
            this.RSAService = new RSACryptoServiceProvider();
        }

        public byte[] CreatePublicKey()
        {
            string xmlPublicKey = this.RSAService.ToXmlString(false);
            return Encoding.ASCII.GetBytes(xmlPublicKey);
        }

        public byte[] CreatePrivateKey()
        {
            string xmlPrivateKey = this.RSAService.ToXmlString(true);
            return Encoding.ASCII.GetBytes(xmlPrivateKey);
        }

        public static byte[] EncryptText (string text, string xmlPublic)
        {
            RSACryptoServiceProvider RSA = new RSACryptoServiceProvider(1024);
            RSA.FromXmlString(xmlPublic);
            byte[] encryptedData = RSA.Encrypt(Encoding.UTF8.GetBytes(text), false);
            return encryptedData;
        }
        public static byte[] DecryptText(string text, string xmlPrivate)
        {
            var texto = Convert.FromBase64String(text);
            RSACryptoServiceProvider RSA = new RSACryptoServiceProvider(1024);
            RSA.FromXmlString(xmlPrivate);
            byte[] decryptedData = RSA.Decrypt(texto, false);
            return decryptedData;
        }
    }
}
