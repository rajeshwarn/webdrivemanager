// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IFolderSynchronizer.cs" company="Andrin Bürli">
//   (c) Andrin Bürli 2016
// </copyright>
// <summary>
//   Defines the IFolderSynchronizer type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace WebDriveManager.Core
{
    public interface IFolderSynchronizer
    {
        void SynchronizeFolder(GoogleDriveFile googleGoogleDriveFile, string rootFolderPath);
    }
}