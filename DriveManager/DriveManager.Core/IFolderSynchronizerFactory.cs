// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IFolderSynchronizerFactory.cs" company="Andrin Bürli">
//   (c) Andrin Bürli 2016
// </copyright>
// <summary>
//   Defines the IFolderSynchronizerFactory type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace DriveManager.Core
{
    public interface IFolderSynchronizerFactory
    {
        IFolderSynchronizer Create();
    }
}