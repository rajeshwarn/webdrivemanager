// --------------------------------------------------------------------------------------------------------------------
// <copyright file="FileDownloader.cs" company="Andrin Bürli">
//   (c) Andrin Bürli 2016
// </copyright>
// <summary>
//   Defines the FileDownloader type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace WebDriveManager.GoogleDrive
{
    using System;

    using Google.Apis.Drive.v2.Data;

    public class FileDownloader : IFileDownloader
    {
        private readonly GoogleDriveServiceProvider driveServiceProvider;

        public FileDownloader(GoogleDriveServiceProvider driveServiceProvider)
        {
            this.driveServiceProvider = driveServiceProvider;
        }

        public bool Download(GoogleDriveFile googleDriveFile, string targetFolder)
        {
            if (string.IsNullOrEmpty(googleDriveFile.DownloadUrl) == false)
            {
                try
                {
                    var request = this.driveServiceProvider.GetService()
                        .HttpClient.GetByteArrayAsync(googleDriveFile.DownloadUrl);
                    byte[] fileData = request.Result;
                    System.IO.File.WriteAllBytes(targetFolder + "\\" + googleDriveFile.Title, fileData);
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