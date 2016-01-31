﻿// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IWebDriveAccount.cs" company="Andrin Bürli">
//   (c) Andrin Bürli 2016
// </copyright>
// <summary>
//   Defines the IWebDriveAccount type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace WebDriveManager.Core
{
    public interface IWebDriveAccount : IReadOnlyWebDriveAccount
    {
        void UpdateAccount();
    }
}