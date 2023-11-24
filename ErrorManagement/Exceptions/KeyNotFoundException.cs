using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace rpg.ErrorManagement.Exceptions
{
    public class KeyNotFoundException : Exception
    {
        public KeyNotFoundException(string message) : base(message)
        { }
    }
}