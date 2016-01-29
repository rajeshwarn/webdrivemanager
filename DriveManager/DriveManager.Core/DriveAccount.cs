namespace DriveManager.Core
{
    public class DriveAccount
    {
        public DriveAccount()
        {
            this.IsAuthenticated = false;
        }

        public void Authenticate()
        {
            throw new System.NotImplementedException();
        }

        public bool IsAuthenticated { get; private set; }
    }
}