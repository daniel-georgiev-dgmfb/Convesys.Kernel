using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;
using Convesys.Kernel.Mime;

namespace Convesys.Kernel.Mime.Tests.L0
{
    [TestFixture]
    [Category("L0")]
    public class MimeHeaderTests
    {
        private const string ExpectedField = "foo";
        private const string ExpectedValue = "bar";

        [TestFixture]
        public class Constructor : MimeHeaderTests
        {
            [TestCase(null, ExpectedValue)]
            [TestCase("", ExpectedValue)]
            public void Field_Can_Not_Be_Null_Or_Empty(string field, string value)
            {
                //Arrange

                //Act
                MimeHeader TestDelegate() => new MimeHeader(field, value);

                //Assert
                Assert.That(TestDelegate,
                    Throws.ArgumentException.With.Message.EqualTo("field cannot be Null or Empty"));
            }

            [TestCase(ExpectedField, null)]
            [TestCase(ExpectedField, "")]
            public void Value_Can_Be_Null_Or_Empty(string field, string value)
            {
                //Arrange

                //Act
                var result = new MimeHeader(field, value);

                //Assert
                Assert.That(result, Is.Not.Null);
                Assert.That(result.Field, Is.EqualTo(ExpectedField));
            }

            [Test]
            public void Can_Be_Constructed()
            {
                //Arrange

                //Act
                var result = new MimeHeader(ExpectedField, ExpectedValue);

                //Assert
                Assert.That(result, Is.Not.Null);
                Assert.That(result.Field, Is.EqualTo(ExpectedField));
                Assert.That(result.Value, Is.EqualTo(ExpectedValue));
            }
        }

        [TestFixture]
        public class EqualsMethod : MimeHeaderTests
        {
            [Test]
            public void Are_Equal()
            {
                //Arrange
                var header = new MimeHeader(ExpectedField, ExpectedValue);
                var other = new MimeHeader(ExpectedField, ExpectedValue);

                //Act
                var result = header.Equals(other);

                //Assert
                Assert.That(result, Is.True);
            }

            [Test]
            public void Are_Not_Equal()
            {
                //Arrange
                var header = new MimeHeader(ExpectedField, ExpectedValue);
                var other = new MimeHeader(ExpectedValue, ExpectedField);

                //Act
                var result = header.Equals(other);

                //Assert
                Assert.That(result, Is.False);
            }

            [Test]
            public void Collection_Can_Be_Equal()
            {
                //Arrange
                var headersList = new List<MimeHeader>
                {
                    new MimeHeader(ExpectedField, ExpectedValue),
                    new MimeHeader(ExpectedValue, ExpectedField)
                };
                var otherList = new List<MimeHeader>
                {
                    new MimeHeader(ExpectedField, ExpectedValue),
                    new MimeHeader(ExpectedValue, ExpectedField)
                };

                //Act
                var result = headersList.SequenceEqual(otherList);

                //Assert
                Assert.That(result, Is.True);
            }

            [Test]
            public void Null_Other_Returns_False()
            {
                //Arrange
                var header = new MimeHeader(ExpectedField, ExpectedValue);

                //Act
                var result = header.Equals(null);

                //Assert
                Assert.That(result, Is.False);
            }
        }

        [TestFixture]
        public class GetHashCodeMethod : MimeHeaderTests
        {
            [Test]
            public void Returns_Correct_Value()
            {
                //Arrange
                var header = new MimeHeader(ExpectedField, ExpectedValue);

                //Act
                var result = header.GetHashCode();

                //Assert
                Assert.That(result, Is.Not.EqualTo(0));
            }
        }
    }
}
