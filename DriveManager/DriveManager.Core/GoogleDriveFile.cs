// --------------------------------------------------------------------------------------------------------------------
// <copyright file="DriveFile.cs" company="Andrin Bürli">
//   (c) Andrin Bürli 2016
// </copyright>
// <summary>
//   Defines the DriveFile type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace DriveManager.Core
{
    using System.Collections.Generic;

    using Google.Apis.Drive.v2.Data;

    public class DriveFile
    {
        private readonly File actualDriveFile;

        public DriveFile(File actualDriveFile)
        {
            this.actualDriveFile = actualDriveFile;
        }

        public string Id
        {
            get
            {
                return this.actualDriveFile.Id;
            }
        }

        public string MimeType
        {
            get
            {
                return this.actualDriveFile.MimeType;
            }
        }

        public IList<ParentReference> Parents
        {
            get
            {
                return this.actualDriveFile.Parents;
            }
        }

        public string Title
        {
            get
            {
                return this.actualDriveFile.Title;
            }
        }

        public string DownloadUrl
        {
            get
            {
                return this.actualDriveFile.DownloadUrl;
            }
        }
    }
}