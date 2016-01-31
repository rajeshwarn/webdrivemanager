// --------------------------------------------------------------------------------------------------------------------
// <copyright file="AuthenticatorFactory.cs" company="Andrin Bürli">
//   (c) Andrin Bürli 2016
// </copyright>
// <summary>
//   Defines the AuthenticatorFactory type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace WebDriveManager.GoogleDrive
{
    public class AuthenticatorFactory
    {
        public IAuthenticator Create()
        {
            return new Authenticator();
        }
    }
}