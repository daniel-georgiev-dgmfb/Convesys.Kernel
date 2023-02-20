using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Twilight.Kernel.Extensions;
using NUnit.Framework;

namespace Twilight.Kernel.Tests.L0.Extensions
{
    [TestFixture, Category("StringExtensions")]
    public class StringExtensionsTests
    {
        [Test]
        public void SecureString_test()
        {
            //ARRANGE
            var expected = "Test string";
            var source = "Test string";
            //ACT
            var secureString = StringExtensions.ToSecureString(source);
            var unsecureString = StringExtensions.ToInsecureString(secureString);
            //ASSERT
            Assert.AreEqual(expected, unsecureString);
        }

        [Test]
        public void SecureString_null_source_test()
        {
            //ARRANGE
            var expected = String.Empty;
            //ACT
            var secureString = StringExtensions.ToSecureString(null);
            var unsecureString = StringExtensions.ToInsecureString(secureString);
            //ASSERT
            Assert.AreEqual(expected, unsecureString);
        }

        [Test]
        public void SecureString_empty_source_test()
        {
            //ARRANGE
            var expected = String.Empty;
            //ACT
            var secureString = StringExtensions.ToSecureString(String.Empty);
            var unsecureString = StringExtensions.ToInsecureString(secureString);
            //ASSERT
            Assert.AreEqual(expected, unsecureString);
        }

        [Test]
        public void String_to_Stream_null_source_test()
        {
            //ARRANGE
           
            //ACT
            
            //ASSERT
            Assert.Throws<ArgumentNullException>(() => StringExtensions.ToStream(null, Encoding.UTF8));
        }

        [Test]
        public void String_to_Stream_null_encoding_test()
        {
            //ARRANGE

            //ACT

            //ASSERT
            Assert.Throws<ArgumentNullException>(() => StringExtensions.ToStream(null, Encoding.UTF8));
        }

        [Test]
        public void String_to_Stream_test()
        {
            //ARRANGE
            var expected = "123";
            var source = "123";
            //ACT
            var stream = StringExtensions.ToStream(source, Encoding.UTF8);
            var streamToCopyTo = new MemoryStream((int)stream.Length);
            stream.CopyTo(streamToCopyTo);
            var result = Encoding.UTF8.GetString(streamToCopyTo.GetBuffer());
            //ASSERT
            Assert.AreEqual(expected, result);
        }
    }
}
