// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IFileDownloader.cs" company="Andrin Bürli">
//   (c) Andrin Bürli 2016
// </copyright>
// <summary>
//   Defines the IFileDownloader type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace WebDriveManager.GoogleDrive
{
    public interface IFileDownloader
    {
        bool Download(GoogleDriveFile googleDriveFile, string targetFolder);
    }
}