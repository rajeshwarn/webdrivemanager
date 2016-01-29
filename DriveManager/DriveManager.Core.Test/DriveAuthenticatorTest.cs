namespace DriveManager.Core.Test
{
    using FluentAssertions;
    using NUnit.Framework;

    [TestFixture]
    public class DriveAuthenticatorTest
    {
        private DriveAuthenticator testee;

        [SetUp]
        public void Setup()
        {
            this.testee = new DriveAuthenticator();
        }

        [Test]
        public void WhenAuthentication_ThenAuthenticated()
        {
            // Arrange -

            // Act
            this.testee.Authenticate("test");

            // Assert
            this.testee.IsAuthenticated.Should().BeTrue();
        }
    }
}