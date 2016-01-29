﻿// --------------------------------------------------------------------------------------------------------------------
// <copyright file="DriveAuthenticator.cs" company="Andrin Bürli">
//   (c) Andrin Bürli 2016
// </copyright>
// <summary>
//   Defines the DriveAuthenticator type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace DriveManager.Core
{
    using System;
    using System.IO;
    using System.Threading;
    using Google.Apis.Auth.OAuth2;
    using Google.Apis.Drive.v2;
    using Google.Apis.Util.Store;

    public class DriveAuthenticator
    {
        private static readonly string[] Scopes = { DriveService.Scope.DriveReadonly };

        public UserCredential Credential { get; private set; }

        public bool IsAuthenticated
        {
            get { return this.Credential != null; }
        }

        public void Authenticate(string username)
        {
            using (var stream = new FileStream("client_id.json", FileMode.Open, FileAccess.Read))
            {
                string credPath = System.Environment.GetFolderPath(
                    System.Environment.SpecialFolder.ApplicationData);
                credPath = Path.Combine(credPath, "DriveManager\\.credentials/" + username);

                this.Credential = GoogleWebAuthorizationBroker.AuthorizeAsync(
                    GoogleClientSecrets.Load(stream).Secrets,
                    Scopes,
                    "user",
                    CancellationToken.None,
                    new FileDataStore(credPath, true)).Result;
                Console.WriteLine("Credential file saved to: " + credPath);
            }
        }
    }
}