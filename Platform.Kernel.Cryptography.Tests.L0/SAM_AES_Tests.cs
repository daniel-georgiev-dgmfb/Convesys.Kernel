using Encryption;
using Kernel.Cryptography.DataProtection;
using NUnit.Framework;
using System;
using System.IO;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Platform.Kernel.Cryptography.Tests.L0
{
	[TestFixture]
    public class SAM_AES_Tests
    {
        [Test]
        public async Task Foo()
        {
            var text = "foo";
            var encodings = Encoding.GetEncodings();
            var e = Encoding.Default;
            var utext = Encoding.Unicode.GetBytes(text);
            var u8 = Encoding.Convert(Encoding.Unicode, Encoding.UTF8, utext);
            var rs = ASCIIEncoding.Unicode;
            var d = Encoding.UTF8.GetString(u8);
            var d1 = Encoding.Unicode.GetString(utext);
            //Encoding.
            //var foo = Encoding.GetEncoding(text);

        }

        [Test]
        public async Task Encrypt()
        {
            //ARRANGE
            var file = await File.ReadAllBytesAsync("D:\\Dan\\SAM\\sam");
            using (Aes aesAlg = Aes.Create())
            {
                var foo = AESCryptoProvider.EncryptStringToBytes_Aes("aaa",aesAlg.Key, aesAlg.IV);
            }
            
            var fileEnc = AESAndSigned.EncryptWithPassword(file, "KGS!@#$%");
            var fileDec = AESAndSigned.DecryptWithPassword(fileEnc, "KGS!@#$%");
            var fc = AESAndSigned.DecryptWithPassword(file, "KGS!@#$%");
            //var decryptor = new PasswordEncryptor();
            var plainTextSource = "Test data to encrypt";
            var result = String.Empty;
            byte[] salt;
            //ACT
            var encrypted = AESAndSigned.EncryptWithPassword("Password1", plainTextSource);
            result = AESAndSigned.DecryptWithPassword(encrypted, "Password1");
            //ASSERT
            Assert.AreEqual(plainTextSource, result);
        }

        [Test]
        public void Decrypt()
        {
            //ARRANGE
            var encryptor = new PasswordEncryptor();
            var decryptor = new PasswordEncryptor();
            var plainTextSource = "Test data to encrypt";
            var result = String.Empty;
            byte[] salt;
            //ACT
            var encrypted = encryptor.Encrypt("Password1", plainTextSource, out salt);
            result = decryptor.Decrypt("Password1", salt, encrypted);
            //ASSERT
            Assert.AreEqual(plainTextSource, result);
        }
    }
}
