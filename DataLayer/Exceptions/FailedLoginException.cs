using System;
using System.Collections.Generic;
using System.Text;

namespace SilentCreekRoleplay.DataLayer.Exceptions
{
    public class FailedLoginException : Exception
    {
        public FailedLoginException()
        {
        }

        public FailedLoginException(string message)
            : base(message)
        {
        }

        public FailedLoginException(string message, Exception inner)
            : base(message, inner)
        {
        }
    }
}
