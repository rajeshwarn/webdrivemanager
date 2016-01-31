// --------------------------------------------------------------------------------------------------------------------
// <copyright file="DriveFileDownloaderTest.cs" company="Andrin Bürli">
//   (c) Andrin Bürli 2016
// </copyright>
// <summary>
//   Defines the DriveFileDownloaderTest type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace DriveManager.Core.Test
{
    using System;
    using System.IO;
    using System.Linq;

    using FluentAssertions;

    using NUnit.Framework;

    [TestFixture]
    public class DriveFileDownloaderTest
    {
        private DriveFileDownloader testee;

        private GoogleDriveServiceProvider googleDriveServiceProvider;

        [SetUp]
        public void Setup()
        {
            var driveAuthenticator = new Authenticator();
            driveAuthenticator.Authenticate("test");
            this.googleDriveServiceProvider = new GoogleDriveServiceProvider(driveAuthenticator);
            this.testee = new DriveFileDownloader(this.googleDriveServiceProvider);
        }

        [Test]
        public void Download_WhenFileIsDownloaded_ThenItIsCorrect()
        {
            // Arrange
            var driveFileGetter = new FilesGetter(this.googleDriveServiceProvider);
            var driveFiles = driveFileGetter.GetDriveFiles(string.Empty).ToList();

            // Act
            string rootFolder = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "\\TestGoogleDrive";
            this.testee.Download(driveFiles[0], rootFolder);

            // Assert
            Directory.GetFiles(rootFolder).Any().Should().BeTrue();
        }
    }
}