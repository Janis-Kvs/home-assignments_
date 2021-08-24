using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IfRisk.Exceptions
{
    public class PolicyDoesNotExistException : Exception
    {
        public PolicyDoesNotExistException()
        {
        }

        public PolicyDoesNotExistException(string message)
            : base(message)
        {
        }

        public PolicyDoesNotExistException(string message, Exception inner)
            : base(message, inner)
        {
        }
    }
}
