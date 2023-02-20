using NUnit.Framework;

namespace Twilight.Kernel.Mime.Tests.L0
{
    [TestFixture]
    [Category("L0")]
    public class MailboxTests
    {
        private const string User = "Barry";
        private const string Host = "VonBarriton.com";
        private const string DisplayName = "Barry Von Barriton";

        [TestFixture]
        public class Constructor : MailboxTests
        {
            [Test]
            public void Can_Be_Constructed_With_Zero_Arguments()
            {
                //Arrange

                //Act
                var result = new Mailbox();

                //Assert
                Assert.That(result, Is.Not.Null);
                Assert.That(result.User, Is.Null);
                Assert.That(result.Host, Is.Null);
                Assert.That(result.DisplayName, Is.Null);
            }

            [Test]
            public void Can_Be_Constructed_With_User_And_Host()
            {
                //Arrange

                //Act
                var result = new Mailbox(User, Host);

                //Assert
                Assert.That(result, Is.Not.Null);
                Assert.That(result.User, Is.EqualTo(User));
                Assert.That(result.Host, Is.EqualTo(Host));
                Assert.That(result.DisplayName, Is.Null);
            }

            [Test]
            public void Can_Be_Constructed_With_Address()
            {
                //Arrange

                //Act
                var result = new Mailbox(string.Join('@', User, Host));

                //Assert
                Assert.That(result, Is.Not.Null);
                Assert.That(result.User, Is.EqualTo(User));
                Assert.That(result.Host, Is.EqualTo(Host));
                Assert.That(result.DisplayName, Is.Null);
            }
        }

        [TestFixture]
        public class UserProperty : MailboxTests
        {
            [Test]
            public void Can_Get()
            {
                //Arrange
                var mailbox = new Mailbox(User, Host);

                //Act
                var result = mailbox.User;

                //Assert
                Assert.That(result, Is.EqualTo(User));
            }

            [Test]
            public void Can_Set()
            {
                //Arrange
                var mailbox = new Mailbox();

                //Act
                mailbox.User = User;

                //Assert
                Assert.That(mailbox.User, Is.EqualTo(User));
            }
        }

        [TestFixture]
        public class HostProperty : MailboxTests
        {
            [Test]
            public void Can_Get()
            {
                //Arrange
                var mailbox = new Mailbox(User, Host);

                //Act
                var result = mailbox.Host;

                //Assert
                Assert.That(result, Is.EqualTo(Host));
            }

            [Test]
            public void Can_Set()
            {
                //Arrange
                var mailbox = new Mailbox();

                //Act
                mailbox.Host = Host;

                //Assert
                Assert.That(mailbox.Host, Is.EqualTo(Host));
            }
        }

        [TestFixture]
        public class DisplayNameProperty : MailboxTests
        {
            [Test]
            public void Can_Get_And_Set()
            {
                //Arrange
                var mailbox = new Mailbox();

                //Act
                mailbox.DisplayName = DisplayName;
                var result = mailbox.DisplayName;

                //Assert
                Assert.That(result, Is.EqualTo(DisplayName));
            }
        }

        [TestFixture]
        public class AsAddressMethod : MailboxTests
        {
            [TestCase(null, null)]
            [TestCase("", null)]
            [TestCase(User, null)]
            [TestCase(null, Host)]
            [TestCase(null, "")]
            [TestCase("", "")]
            public void Returns_Null(string user, string host)
            {
                //Arrange
                var mailbox = new Mailbox(user, host);

                //Act
                var result = mailbox.AsAddress();

                //Assert
                Assert.That(result, Is.Null);
            }

            [Test]
            public void Returns_Address_As_String()
            {
                //Arrange
                var expectedAddress = string.Join('@', User, Host);
                var mailbox = new Mailbox(User, Host);

                //Act
                var result = mailbox.AsAddress();

                //Assert
                Assert.That(result, Is.EqualTo(expectedAddress));
            }

            [Test]
            public void Returns_Address_As_String_After_Property_Values_Change()
            {
                //Arrange
                var expectedAddress = string.Join('@', User, Host);
                var mailbox = new Mailbox();

                //Act
                mailbox.User = User;
                mailbox.Host = Host;
                var result = mailbox.AsAddress();

                //Assert
                Assert.That(result, Is.EqualTo(expectedAddress));
            }
        }

        [TestFixture]
        public class EmptyStaticProperty : MailboxTests
        {
            [Test]
            public void Returns_Empty_Mailbox()
            {
                //Arrange

                //Act
                var result = Mailbox.Empty;

                //Assert
                Assert.That(result, Is.Not.Null);
                Assert.That(result.User, Is.Empty);
                Assert.That(result.Host, Is.Empty);
            }

            [Test]
            public void Empty_Mailbox_As_Address_Returns_Null()
            {
                //Arrange
                var mailbox = Mailbox.Empty;

                //Act
                var result = mailbox.AsAddress();

                //Assert
                Assert.That(result, Is.Null);
            }
        }
    }
}
