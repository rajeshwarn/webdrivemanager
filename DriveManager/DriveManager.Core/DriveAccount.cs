namespace DriveManager.Core
{
    public class DriveAccount
    {
        private readonly DriveAuthenticator driveAuthenticator;

        public DriveAccount(DriveAuthenticator driveAuthenticator)
        {
            this.driveAuthenticator = driveAuthenticator;
        }

        public void Authenticate()
        {
            this.driveAuthenticator.Authenticate();
        }

        public bool IsAuthenticated
        {
            get { return this.driveAuthenticator.IsAuthenticated; }
        }
    }
}