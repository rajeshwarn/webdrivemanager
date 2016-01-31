﻿// --------------------------------------------------------------------------------------------------------------------
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
        private FilesGetter testee;

        [SetUp]
        public void Setup()
        {
            Authenticator driveAuthenticator = new Authenticator();
            driveAuthenticator.Authenticate("test");
            this.testee = new FilesGetter(new GoogleDriveServiceProvider(driveAuthenticator));
        }

        [Test]
        public void GetFiles_WhenFilesAreGetted_ThenThereAreAny()
        {
            // Arrange -
            
            // Act
            IEnumerable<DriveFile> rootFolders = this.testee.GetDriveFiles(GoogleDriveConstants.FolderMimeType);

            // Assert
            rootFolders.Any().Should().BeTrue();
        }
    }
}