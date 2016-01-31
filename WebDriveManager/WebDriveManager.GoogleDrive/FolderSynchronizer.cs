// --------------------------------------------------------------------------------------------------------------------
// <copyright file="FolderSynchronizer.cs" company="Andrin Bürli">
//   (c) Andrin Bürli 2016
// </copyright>
// <summary>
//   Defines the FolderSynchronizer type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace WebDriveManager.GoogleDrive
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

        public void SynchronizeFolder(GoogleDriveFile folderToSynchronize, string rootFolder)
        {
            this.EnsureThatDriveFileIsAFolder(folderToSynchronize);
            this.SynchronizeContentOfFolder(
                folderToSynchronize,
                rootFolder,
                this.filesGetter.GetDriveFiles(GoogleDriveConstants.AnyFileType).ToList());
        }

        private void SynchronizeContentOfFolder(GoogleDriveFile folderToSynchronize, string rootFolder, List<GoogleDriveFile> allDriveFiles)
        {
            string currentFolder = rootFolder + "\\" + folderToSynchronize.Title;
            Directory.CreateDirectory(currentFolder);

            var childDriveFiles = this.GetChildDriveFiles(folderToSynchronize, allDriveFiles);

            foreach (GoogleDriveFile childDriveFile in childDriveFiles)
            {
                allDriveFiles.Remove(childDriveFile);
            }

            foreach (GoogleDriveFile childDriveFile in childDriveFiles)
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

        private List<GoogleDriveFile> GetChildDriveFiles(GoogleDriveFile folderToSynchronize, List<GoogleDriveFile> allDriveFiles)
        {
            List<GoogleDriveFile> childDriveFiles = allDriveFiles.Where(o => this.DriveFileIsInFolder(folderToSynchronize, o)).ToList();
            return childDriveFiles;
        }

        private bool DriveFileIsInFolder(GoogleDriveFile folderToSynchronize, GoogleDriveFile o)
        {
            return o.Parents.Any() && o.Parents.Single().Id == folderToSynchronize.Id;
        }

        private void EnsureThatDriveFileIsAFolder(GoogleDriveFile folderToSynchronize)
        {
            if (folderToSynchronize.MimeType != GoogleDriveConstants.FolderMimeType)
            {
                throw new InvalidOperationException("GoogleDriveFile " + folderToSynchronize.Title + " is not a Folder.");
            }
        }
    }
}