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

        private DriveServiceProvider driveServiceProvider;

        [SetUp]
        public void Setup()
        {
            var driveAuthenticator = new DriveAuthenticator();
            driveAuthenticator.Authenticate("test");
            this.driveServiceProvider = new DriveServiceProvider(driveAuthenticator);
            this.testee = new DriveFileDownloader(this.driveServiceProvider);
        }

        [Test]
        public void Download_WhenFileIsDownloaded_ThenItIsCorrect()
        {
            // Arrange
            var driveFileGetter = new DriveFilesGetter(this.driveServiceProvider);
            var driveFiles = driveFileGetter.GetDriveFiles(string.Empty).ToList();

            // Act
            string rootFolder = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "\\TestGoogleDrive";
            this.testee.Download(driveFiles[0], rootFolder);

            // Assert
            Directory.GetFiles(rootFolder).Any().Should().BeTrue();
        }
    }
}