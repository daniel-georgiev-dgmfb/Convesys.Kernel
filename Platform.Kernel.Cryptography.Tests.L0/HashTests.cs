using Kernel.Cryptography.DataProtection;
using NUnit.Framework;
using System;
using System.Security.Cryptography;

namespace Platform.Kernel.Cryptography.Tests.L0
{
	[TestFixture]
    public class HashTests
    {
        [Test]
        public void Hash1()
        {
            //ARRANGE
            var plainTextSource = "VK7JGNPHTMC97JM9MPGT3V66T";
            var hashAlg = new Md4Hash();
            string hash;
            //ACT
            using(var hashImp = new Md4Hash())
            {
                hash = hashImp.ComputeHash(plainTextSource);
            }
            
            //ASSERT
            Assert.AreEqual("ac50cc9265bb54b6a905419be625c6f2", hash);
        }

        [Test]
        public void Hash2_()
        {
            //ARRANGE
            var plainTextSource = "OLDPASSWORD";
            var hashAlg = new Md4Hash();
            var hash1 = HashAlgorithm.Create("DES");
            string hash;
            //ACT
            using (var hashImp = new Md4Hash())
            {
                hash = hashImp.ComputeHash(plainTextSource);
            }

            //ASSERT
            Assert.AreEqual("ac50cc9265bb54b6a905419be625c6f2", hash);
        }

        [Test]
        public void Hash2()
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
