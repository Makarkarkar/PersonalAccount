namespace Personal_Account.Middleware.MiddlewareException
{

    public class LockTimeOutException : Exception

    {

        public LockTimeOutException() : base()
        {
        }

        public LockTimeOutException(string message) : base(message)
        {
        }
    }
}