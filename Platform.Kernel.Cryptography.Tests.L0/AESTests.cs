using Encryption;
using Kernel.Cryptography.DataProtection;
using NUnit.Framework;
using System;

namespace Platform.Kernel.Cryptography.Tests.L0
{
	[TestFixture]
    public class AESTests
    {
        [Test]
        public void Encrypt()
        {
            //ARRANGE
            
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
