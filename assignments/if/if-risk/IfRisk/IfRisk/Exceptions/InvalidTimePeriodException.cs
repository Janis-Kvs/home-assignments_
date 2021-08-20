using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IfRisk.Exceptions
{
    public class InvalidTimePeriodException : Exception
    {
        public InvalidTimePeriodException()
        {
        }

        public InvalidTimePeriodException(string message)
            : base(message)
        {
        }

        public InvalidTimePeriodException(string message, Exception inner)
            : base(message, inner)
        {
        }
    }
}
