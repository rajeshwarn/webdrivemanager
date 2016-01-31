// --------------------------------------------------------------------------------------------------------------------
// <copyright file="GoogleDriveAccountFactory.cs" company="Andrin Bürli">
//   (c) Andrin Bürli 2016
// </copyright>
// <summary>
//   Defines the GoogleDriveAccountFactory type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace WebDriveManager.GoogleDrive
{
    using WebDriveManager.Core;
    
    public class GoogleDriveAccountFactory : IWebDriveAccountFactory
    {
        private readonly AuthenticatorFactory authenticatorFactory;

        private readonly IFilesGetterFactory filesGetterFactory;

        private readonly IFolderSynchronizerFactory folderSynchronizerFactory;

        public GoogleDriveAccountFactory(
            AuthenticatorFactory authenticatorFactory,
            IFilesGetterFactory filesGetterFactory,
            IFolderSynchronizerFactory folderSynchronizerFactory)
        {
            this.authenticatorFactory = authenticatorFactory;
            this.filesGetterFactory = filesGetterFactory;
            this.folderSynchronizerFactory = folderSynchronizerFactory;
        }

        public IWebDriveAccount Create(string username, string rootFolderPath)
        {
            return new GoogleDriveAccount(
                username, 
                rootFolderPath,
                this.authenticatorFactory.Create(),
                this.filesGetterFactory.Create(),
                this.folderSynchronizerFactory.Create());
        }
    }
}