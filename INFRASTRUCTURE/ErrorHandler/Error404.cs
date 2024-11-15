namespace INFRASTRUCTURE.ErrorHandler;

public class Error404 : Exception
{
    public Error404(string message) : base(message)
    {
    }
}