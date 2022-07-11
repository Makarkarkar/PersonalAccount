namespace Personal_Account.Middleware.MiddlewareException;

public class TicketNumberValidateException : Exception
{
    public TicketNumberValidateException() : base(){}
    public TicketNumberValidateException(string message) : base(message){}
}