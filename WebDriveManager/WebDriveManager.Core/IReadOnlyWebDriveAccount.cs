// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IReadOnlyWebDriveAccount.cs" company="Andrin Bürli">
//   (c) Andrin Bürli 2016
// </copyright>
// <summary>
//   Defines the IReadOnlyWebDriveAccount type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace WebDriveManager.Core
{
    public interface IReadOnlyWebDriveAccount
    {
        string Username { get; }

        string RootFolderPath { get; }
    }
}