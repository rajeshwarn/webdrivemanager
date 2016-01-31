// --------------------------------------------------------------------------------------------------------------------
// <copyright file="DriveFileDownloader.cs" company="Andrin Bürli">
//   (c) Andrin Bürli 2016
// </copyright>
// <summary>
//   Defines the DriveFileDownloader type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace DriveManager.Core
{
    using System;
    using System.IO;

    public class DriveFileDownloader : IDriveFileDownloader
    {
        private readonly DriveServiceProvider driveServiceProvider;

        public DriveFileDownloader(DriveServiceProvider driveServiceProvider)
        {
            this.driveServiceProvider = driveServiceProvider;
        }

        public bool Download(DriveFile driveFile, string targetFolder)
        {
            if (string.IsNullOrEmpty(driveFile.DownloadUrl) == false)
            {
                try
                {
                    var request = this.driveServiceProvider.GetService()
                        .HttpClient.GetByteArrayAsync(driveFile.DownloadUrl);
                    byte[] fileData = request.Result;
                    File.WriteAllBytes(targetFolder + "\\" + driveFile.Title, fileData);
                    return true;
                }
                catch (Exception e)
                {
                    Console.WriteLine("An error occurred: " + e.Message);
                    return false;
                }
            }
            else
            {
                // The file doesn't have any content stored on Drive.
                return false;
            }
        }
    }
}