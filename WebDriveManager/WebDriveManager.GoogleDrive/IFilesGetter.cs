// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IFilesGetter.cs" company="Andrin Bürli">
//   (c) Andrin Bürli 2016
// </copyright>
// <summary>
//   Defines the IFilesGetter type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace WebDriveManager.GoogleDrive
{
    using System.Collections.Generic;

    public interface IFilesGetter
    {
        IEnumerable<GoogleDriveFile> GetDriveFiles(string mimeType);
    }
}