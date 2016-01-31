// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IFolderSynchronizerFactory.cs" company="Andrin B�rli">
//   (c) Andrin B�rli 2016
// </copyright>
// <summary>
//   Defines the IFolderSynchronizerFactory type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace WebDriveManager.Core
{
    public interface IFolderSynchronizerFactory
    {
        IFolderSynchronizer Create();
    }
}