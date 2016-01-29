namespace DriveManager.Core.Test
{
    using NUnit.Framework;

    [TestFixture]
    public class DriveFileGetterTest
    {
        private DriveTopFolderGetter testee;

        [SetUp]
        public void Setup()
        {
            this.testee = new DriveTopFolderGetter();
        }

        [Test]
        public void GetFiles_WhenFilesAreGetted_ThenThereAreAny()
        {
            // Arrange
            DriveAuthenticator driveAuthenticator = new DriveAuthenticator();
            driveAuthenticator.Authenticate("test");

            // Act
            this.testee.GetTopFoldersOf(driveAuthenticator.Credential);

            // Assert
        }
    }
}