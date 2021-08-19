using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IfScooters.Exceptions
{
    [Serializable]
    public class NegativePricePerMinuteException : Exception
    {
        public NegativePricePerMinuteException() { }

        public NegativePricePerMinuteException(string message)
            : base(message) { }

        public NegativePricePerMinuteException(string message, Exception inner)
            : base(message, inner) { }
    }
}
