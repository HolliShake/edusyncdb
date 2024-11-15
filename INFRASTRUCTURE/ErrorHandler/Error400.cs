

namespace INFRASTRUCTURE.ErrorHandler;

public class Error400 : Exception
{
    public Error400(string message):base(message)
    {
        
    }
}