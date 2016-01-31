// --------------------------------------------------------------------------------------------------------------------
// <copyright file="FolderSynchronizer.cs" company="Andrin Bürli">
//   (c) Andrin Bürli 2016
// </copyright>
// <summary>
//   Defines the FolderSynchronizer type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace DriveManager.Core
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;

    public class FolderSynchronizer : IFolderSynchronizer
    {
        private readonly IFilesGetter filesGetter;

        private readonly IFileDownloader driveFileDownloader;

        public FolderSynchronizer(IFilesGetter filesGetter, IFileDownloader driveFileDownloader)
        {
            this.filesGetter = filesGetter;
            this.driveFileDownloader = driveFileDownloader;
        }

        public void SynchronizeFolder(DriveFile folderToSynchronize, string rootFolder)
        {
            this.EnsureThatDriveFileIsAFolder(folderToSynchronize);
            this.SynchronizeContentOfFolder(
                folderToSynchronize,
                rootFolder,
                this.filesGetter.GetDriveFiles(GoogleDriveConstants.AnyFileType).ToList());
        }

        private void SynchronizeContentOfFolder(DriveFile folderToSynchronize, string rootFolder, List<DriveFile> allDriveFiles)
        {
            string currentFolder = rootFolder + "\\" + folderToSynchronize.Title;
            Directory.CreateDirectory(currentFolder);

            var childDriveFiles = this.GetChildDriveFiles(folderToSynchronize, allDriveFiles);

            foreach (DriveFile childDriveFile in childDriveFiles)
            {
                allDriveFiles.Remove(childDriveFile);
            }

            foreach (DriveFile childDriveFile in childDriveFiles)
            {
                if (childDriveFile.MimeType == GoogleDriveConstants.FolderMimeType)
                {
                    this.SynchronizeContentOfFolder(
                        childDriveFile, 
                        currentFolder,
                        allDriveFiles);
                }
                else
                {
                    this.driveFileDownloader.Download(childDriveFile, currentFolder);
                }
            }
        }

        private List<DriveFile> GetChildDriveFiles(DriveFile folderToSynchronize, List<DriveFile> allDriveFiles)
        {
            List<DriveFile> childDriveFiles = allDriveFiles.Where(o => this.DriveFileIsInFolder(folderToSynchronize, o)).ToList();
            return childDriveFiles;
        }

        private bool DriveFileIsInFolder(DriveFile folderToSynchronize, DriveFile o)
        {
            return o.Parents.Any() && o.Parents.Single().Id == folderToSynchronize.Id;
        }

        private void EnsureThatDriveFileIsAFolder(DriveFile folderToSynchronize)
        {
            if (folderToSynchronize.MimeType != GoogleDriveConstants.FolderMimeType)
            {
                throw new InvalidOperationException("DriveFile " + folderToSynchronize.Title + " is not a Folder.");
            }
        }
    }
}