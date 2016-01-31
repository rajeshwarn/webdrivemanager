// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IAuthenticator.cs" company="Andrin Bürli">
//   (c) Andrin Bürli 2016
// </copyright>
// <summary>
//   Defines the IAuthenticator type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace WebDriveManager.Core
{
    using Google.Apis.Http;

    public interface IAuthenticator
    {
        bool IsAuthenticated { get; }

        IConfigurableHttpClientInitializer Credential { get; }

        void Authenticate(string username);
    }
}