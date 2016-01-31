// --------------------------------------------------------------------------------------------------------------------
// <copyright file="AccountManager.cs" company="Andrin Bürli">
//   (c) Andrin Bürli 2016
// </copyright>
// <summary>
//   Defines the AccountManager type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace WebDriveManager.Core
{
    using System.Collections.Generic;

    public class AccountManager
    {
        private readonly IWebDriveAccountFactory webDriveAccountFactory;

        private readonly List<IWebDriveAccount> accounts;

        public AccountManager(IWebDriveAccountFactory webDriveAccountFactory)
        {
            this.webDriveAccountFactory = webDriveAccountFactory;
            this.accounts = new List<IWebDriveAccount>();
        }

        public IEnumerable<IReadOnlyWebDriveAccount> Accounts
        {
            get
            {
                return this.accounts;
            }
        }

        public void UpdateAccounts()
        {
            foreach (var webDriveAccount in this.accounts)
            {
                webDriveAccount.UpdateAccount();
            }
        }

        public void AddAccount(string username, string rootFolderPath)
        {
            IWebDriveAccount webDriveAccount = this.webDriveAccountFactory.Create(username, rootFolderPath);
            webDriveAccount.UpdateAccount();
            this.accounts.Add(webDriveAccount);
        }
    }
}