// --------------------------------------------------------------------------------------------------------------------
// <copyright file="FolderSynchronizerTest.cs" company="Andrin Bürli">
//   (c) Andrin Bürli 2016
// </copyright>
// <summary>
//   Defines the FolderSynchronizerTest type.
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
    public class FolderSynchronizerTest
    {
        private DriveFolderSynchronizer testee;

        [SetUp]
        public void Setup()
        {
            var driveAuthenticator = new DriveAuthenticator();
            driveAuthenticator.Authenticate("test");
            var driveServiceProvider = new DriveServiceProvider(driveAuthenticator);
            this.testee = new DriveFolderSynchronizer(new DriveFilesGetter(driveServiceProvider), new DriveFileDownloader(driveServiceProvider));
        }

        [Test]
        public void Synchronize_WhenFolderIsSynchronize_ThenStructureIsCorrect()
        {
            // Arrange
            var driveAuthenticator = new DriveAuthenticator();
            driveAuthenticator.Authenticate("test");
            var driveFilesGetter = new DriveFilesGetter(new DriveServiceProvider(driveAuthenticator));
            var driveFiles = driveFilesGetter.GetDriveFiles(DriveConstants.FolderMimeType).ToList();

            // Act
            string rootFolder = Environment.GetFolderPath(Environment.SpecialFolder.Personal) + "\\TestGoogleDrive";
            this.testee.SynchronizeFolder(
                driveFiles[1],
                rootFolder);

            // Assert
            Directory.Exists(rootFolder).Should().BeTrue();
            Directory.GetDirectories(rootFolder).Length.Should().Be(1);
        }

        [Test]
        public void Synchronize_WhenFolderIsSynchronize_ThenThereAreAnyFoldersAndFiles()
        {
            // Arrange
            var driveAuthenticator = new DriveAuthenticator();
            driveAuthenticator.Authenticate("test");
            var driveFilesGetter = new DriveFilesGetter(new DriveServiceProvider(driveAuthenticator));
            var driveFiles = driveFilesGetter.GetDriveFiles(DriveConstants.FolderMimeType).ToList();

            // Act
            string rootFolder = Environment.GetFolderPath(Environment.SpecialFolder.Personal) + "\\TestGoogleDrive";
            this.testee.SynchronizeFolder(
                driveFiles[1],
                rootFolder);

            // Assert
            Directory.Exists(rootFolder).Should().BeTrue();
            Directory.GetDirectories(rootFolder).Any().Should().BeTrue();
            Directory.GetFileSystemEntries(rootFolder).Any().Should().BeTrue();
        }
    }
}