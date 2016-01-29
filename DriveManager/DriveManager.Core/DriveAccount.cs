namespace DriveManager.Core
{
    public class DriveAccount
    {
        private readonly DriveAuthenticator driveAuthenticator;

        public DriveAccount(DriveAuthenticator driveAuthenticator)
        {
            this.driveAuthenticator = driveAuthenticator;
        }

        public void Authenticate(string username)
        {
            this.driveAuthenticator.Authenticate(username);
        }

        public bool IsAuthenticated
        {
            get { return this.driveAuthenticator.IsAuthenticated; }
        }
    }
}