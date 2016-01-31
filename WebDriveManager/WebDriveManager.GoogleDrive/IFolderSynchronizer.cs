// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IFolderSynchronizer.cs" company="Andrin Bürli">
//   (c) Andrin Bürli 2016
// </copyright>
// <summary>
//   Defines the IFolderSynchronizer type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace WebDriveManager.GoogleDrive
{
    public interface IFolderSynchronizer
    {
        void SynchronizeFolder(GoogleDriveFile googleGoogleDriveFile, string rootFolderPath);
    }
}