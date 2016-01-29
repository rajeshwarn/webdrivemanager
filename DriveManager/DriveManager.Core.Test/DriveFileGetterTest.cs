// --------------------------------------------------------------------------------------------------------------------
// <copyright file="DriveFileGetterTest.cs" company="Andrin Bürli">
//   (c) Andrin Bürli 2016
// </copyright>
// <summary>
//   Defines the DriveFileGetterTest type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace DriveManager.Core.Test
{
    using System.Collections.Generic;
    using System.Linq;

    using FluentAssertions;

    using Google.Apis.Drive.v2.Data;

    using NUnit.Framework;

    [TestFixture]
    public class DriveFileGetterTest
    {
        private DriveFilesGetter testee;

        [SetUp]
        public void Setup()
        {
            DriveAuthenticator driveAuthenticator = new DriveAuthenticator();
            driveAuthenticator.Authenticate("test");
            this.testee = new DriveFilesGetter(new DriveServiceProvider(driveAuthenticator));
        }

        [Test]
        public void GetFiles_WhenFilesAreGetted_ThenThereAreAny()
        {
            // Arrange -
            
            // Act
            IEnumerable<DriveFile> rootFolders = this.testee.GetDriveFiles(DriveConstants.FolderMimeType);

            // Assert
            rootFolders.Any().Should().BeTrue();
        }
    }
}