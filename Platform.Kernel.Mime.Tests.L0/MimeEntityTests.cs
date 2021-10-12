using NUnit.Framework;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Platform.Kernel.Mime.Tests.L0
{
	[TestFixture]
    [Category("L0")]
    public class MimeEntityTests
    {
        private readonly MemoryStream _helloWorldStream =
            new MemoryStream(new byte[] {72, 101, 108, 108, 111, 32, 87, 111, 114, 108, 100, 33});

        [TestFixture]
        public class Constructor : MimeEntityTests 
        {
            public void Null_Mime_Headers_Will_Throw_Argument_Null_Exception()
            {
                //Arrange

                //Act
                MimeEntity TestDelegate() => new MimeEntity(null, _helloWorldStream);

                //Assert
                Assert.That(TestDelegate, Throws.ArgumentNullException.With.Property("ParamName").EqualTo("headers"));
            }

            [Test]
            public void Null_Content_Will_Throw_Argument_Null_Exception()
            {
                //Arrange
                var headers = new[] {new MimeHeader("foo", "bar")};

                //Act
                MimeEntity TestDelegate() => new MimeEntity(headers, null);

                //Assert
                Assert.That(TestDelegate, Throws.ArgumentNullException.With.Property("ParamName").EqualTo("content"));
            }

            [Test]
            public void Can_Be_Constructed()
            {
                //Arrange
                var headers = new[] { new MimeHeader("foo", "bar") };

                //Act
                var result = new MimeEntity(headers, _helloWorldStream);

                //Assert
                Assert.That(result, Is.Not.Null);
                Assert.That(result.Headers.Count, Is.EqualTo(1));
                Assert.That(result.Content, Is.EqualTo(_helloWorldStream));
            }
        }

        [TestFixture]
        public class EqualsMethod : MimeEntityTests
        {
            [Test]
            public void Are_Equal()
            {
                //Arrange
                var header = new MimeHeader("foo", "bar");
                var entity = new MimeEntity(new [] {header}, _helloWorldStream);
                var other = new MimeEntity(new [] {header}, _helloWorldStream);

                //Act
                var result = entity.Equals(other);

                //Assert
                Assert.That(result, Is.True);
            }

            [Test]
            public void Are_Equal_With_Multiple_Headers()
            {
                //Arrange
                var headersList = new List<MimeHeader>
                {
                    new MimeHeader("foo", "bar"),
                    new MimeHeader("bar", "foo")
                };
                var entity = new MimeEntity(headersList, _helloWorldStream);
                var other = new MimeEntity(headersList, _helloWorldStream);
                
                //Act
                var result = entity.Equals(other);

                //Assert
                Assert.That(result, Is.True);
            }

            [Test]
            public void Are_Not_Equal()
            {
                //Arrange
                var header = new MimeHeader("foo", "bar");
                var headerOther = new MimeHeader("bar", "bar");
                var entity = new MimeEntity(new[] { header }, _helloWorldStream);
                var other = new MimeEntity(new[] { headerOther }, _helloWorldStream);

                //Act
                var result = entity.Equals(other);

                //Assert
                Assert.That(result, Is.False);
            }

            [Test]
            public void Null_Other_Returns_False()
            {
                //Arrange
                var header = new MimeHeader("foo", "bar");
                var entity = new MimeEntity(new[] { header }, _helloWorldStream);

                //Act
                var result = entity.Equals(null);

                //Assert
                Assert.That(result, Is.False);
            }
        }

        [TestFixture]
        public class GetHashCodeMethod : MimeEntityTests
        {
            [Test]
            public void Returns_Correct_Value()
            {
                //Arrange
                var header = new MimeHeader("foo", "bar");
                var entity = new MimeEntity(new[] { header }, _helloWorldStream);

                //Act
                var result = entity.GetHashCode();

                //Assert
                Assert.That(result, Is.Not.EqualTo(0));
            }
        }
    }
}
