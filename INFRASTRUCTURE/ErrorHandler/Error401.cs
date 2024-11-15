using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace INFRASTRUCTURE.ErrorHandler;

public class Error401 : Exception
{
    public Error401(string message) : base(message)
    {
        
    }
}