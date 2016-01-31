// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IWebDriveAccountFactory.cs" company="Andrin Bürli">
//   (c) Andrin Bürli 2016
// </copyright>
// <summary>
//   Defines the IWebDriveAccountFactory type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace WebDriveManager.Core
{
    public interface IWebDriveAccountFactory
    {
        IWebDriveAccount Create(string username, string rootFolderPath);
    }
}