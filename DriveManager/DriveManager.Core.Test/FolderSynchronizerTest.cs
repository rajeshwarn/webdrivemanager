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
        private FolderSynchronizer testee;

        [SetUp]
        public void Setup()
        {
            var authenticator = new Authenticator();
            authenticator.Authenticate("test");
            var serviceProvider = new GoogleDriveServiceProvider(authenticator);
            this.testee = new FolderSynchronizer(new FilesGetter(serviceProvider), new DriveFileDownloader(serviceProvider));
        }

        [Test]
        public void Synchronize_WhenFolderIsSynchronize_ThenStructureIsCorrect()
        {
            // Arrange
            var authenticator = new Authenticator();
            authenticator.Authenticate("test");
            var filesGetter = new FilesGetter(new GoogleDriveServiceProvider(authenticator));
            var files = filesGetter.GetDriveFiles(GoogleDriveConstants.FolderMimeType).ToList();

            // Act
            string rootFolder = Environment.GetFolderPath(Environment.SpecialFolder.Personal) + "\\TestGoogle";
            this.testee.SynchronizeFolder(
                files[1],
                rootFolder);

            // Assert
            Directory.Exists(rootFolder).Should().BeTrue();
            Directory.GetDirectories(rootFolder).Length.Should().Be(1);
        }

        [Test]
        public void Synchronize_WhenFolderIsSynchronize_ThenThereAreAnyFoldersAndFiles()
        {
            // Arrange
            var authenticator = new Authenticator();
            authenticator.Authenticate("test");
            var filesGetter = new FilesGetter(new GoogleDriveServiceProvider(authenticator));
            var files = filesGetter.GetDriveFiles(GoogleDriveConstants.FolderMimeType).ToList();

            // Act
            string rootFolder = Environment.GetFolderPath(Environment.SpecialFolder.Personal) + "\\TestGoogle";
            this.testee.SynchronizeFolder(
                files[1],
                rootFolder);

            // Assert
            Directory.Exists(rootFolder).Should().BeTrue();
            Directory.GetDirectories(rootFolder).Any().Should().BeTrue();
            Directory.GetFileSystemEntries(rootFolder).Any().Should().BeTrue();
        }
    }
}