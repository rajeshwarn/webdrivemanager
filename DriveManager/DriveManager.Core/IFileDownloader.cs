// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IFileDownloader.cs" company="Andrin Bürli">
//   (c) Andrin Bürli 2016
// </copyright>
// <summary>
//   Defines the IFileDownloader type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace DriveManager.Core
{
    public interface IFileDownloader
    {
        bool Download(DriveFile driveFile, string targetFolder);
    }
}