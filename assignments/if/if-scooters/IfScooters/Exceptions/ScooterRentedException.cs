using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IfScooters.Exceptions
{
    [Serializable]
    public class ScooterRentedException : Exception
    {
        public ScooterRentedException() { }

        public ScooterRentedException(string message)
            : base(message) { }

        public ScooterRentedException(string message, Exception inner)
            : base(message, inner) { }
    }
}
