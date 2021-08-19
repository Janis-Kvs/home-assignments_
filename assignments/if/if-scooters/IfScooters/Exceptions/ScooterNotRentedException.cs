using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IfScooters.Exceptions
{
    [Serializable]
    public class ScooterNotRentedException : Exception
    {
        public ScooterNotRentedException() { }

        public ScooterNotRentedException(string message)
            : base(message) { }

        public ScooterNotRentedException(string message, Exception inner)
            : base(message, inner) { }
    }
}
