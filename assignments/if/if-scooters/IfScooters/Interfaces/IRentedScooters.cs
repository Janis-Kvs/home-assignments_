using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace IfScooters
{
    public interface IRentedScooters
    {
        string Id { get; }

        decimal PricePerMinute { get; set; }

        DateTime PickTime { get; set; }

        DateTime ReturnTime { get; set; }

        bool IsRented { get; set; }
    }
}
