using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IfScooters
{
    public struct RentedScooters : IRentedScooters
    {
        public string Id { get; set; }
        public decimal PricePerMinute { get; set; }
        public DateTime PickTime { get; set; }
        public DateTime ReturnTime { get; set; }
        public bool IsRented { get; set; }

        public RentedScooters(string id, decimal price, DateTime pickTime, bool isRented)
        {
            Id = id;
            PricePerMinute = price;
            PickTime = pickTime;
            IsRented = isRented;
            ReturnTime = DateTime.MinValue;
        }
    }
}
