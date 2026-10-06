using System;
using System.Collections.Generic;
using System.Text;

namespace MyContactsApp.Core.Exceptions
{
    public class InvalidContactException : Exception
    {
        public InvalidContactException(string message) : base(message) { }
    }
}
