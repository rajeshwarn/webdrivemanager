// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IFilesGetterFactory.cs" company="Andrin Bürli">
//   (c) Andrin Bürli 2016
// </copyright>
// <summary>
//   Defines the IFilesGetterFactory type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace WebDriveManager.Core
{
    public interface IFilesGetterFactory
    {
        IFilesGetter Create();
    }
}