using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace rpg.ErrorManagement.Exceptions
{
    public class NotImplementedException : Exception
    {
        public NotImplementedException(string message) : base(message)
        { }
    }
}