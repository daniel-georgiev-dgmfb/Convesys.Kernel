using NUnit.Framework;
using Platform.Kernel.Extensions;
using System;
using System.IO;
using System.Text;

namespace Platform.Kernel.Tests.L0.Extensions
{
	[TestFixture]
    public class StreamExtensionTests
    {
        [TestFixture]
        public class ConvertToBase64 : StreamExtensionTests
        {
            [Test]
            public void Converts_A_MemoryStream_To_String()
            {
                // Arrange
                var stream = new MemoryStream(Encoding.UTF8.GetBytes("TestString"));

                // Act
                var base64String = stream.ConvertToString();

                // Assert
                Assert.That(base64String, Is.EqualTo("TestString"));
            }

            [Test]
            public void Null_Input_Stream_Throws_NullArgumentException()
            {
                // Arrange
                Stream stream = null;

                // Act
                var thrownException = Assert.Throws<ArgumentNullException>(() =>
                        stream.ConvertToString()
                );

                // Assert
                Assert.That(thrownException.ParamName, Is.EqualTo("stream"));
            }
        }
    }
}