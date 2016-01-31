// --------------------------------------------------------------------------------------------------------------------
// <copyright file="DriveAuthenticatorTest.cs" company="Andrin Bürli">
//   (c) Andrin Bürli 2016
// </copyright>
// <summary>
//   Defines the DriveAuthenticatorTest type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace DriveManager.Core.Test
{
    using FluentAssertions;

    using NUnit.Framework;

    [TestFixture]
    public class DriveAuthenticatorTest
    {
        private Authenticator testee;

        [SetUp]
        public void Setup()
        {
            this.testee = new Authenticator();
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