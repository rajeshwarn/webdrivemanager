// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IFolderSynchronizer.cs" company="Andrin Bürli">
//   (c) Andrin Bürli 2016
// </copyright>
// <summary>
//   Defines the IFolderSynchronizer type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace DriveManager.Core
{
    public interface IFolderSynchronizer
    {
        void SynchronizeFolder(GoogleDriveFile googleDriveFile, string rootFolderPath);
    }
}