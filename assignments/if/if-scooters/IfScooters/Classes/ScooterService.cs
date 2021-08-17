using IfScooters.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IfScooters
{
    public class ScooterService : IScooterService
    {
        private IList<Scooter> _scooters;

        public ScooterService()
        {
            _scooters = new List<Scooter>();
        }

        public void AddScooter(string id, decimal pricePerMinute)
        {
            if (pricePerMinute >= 0)
            {
                _scooters.Add(new Scooter(id, pricePerMinute));
            }
            else
            {
                throw new NegativePricePerMinuteException("Price per minute should be zero or a positive number!");
            }
        }
        
        public void RemoveScooter(string id)
        {
            var scooter = GetScooterById(id);
            if (scooter.IsRented)
            {
                throw new ScooterRentedException("Cannot remove rented scooter!");
            }
            else
            {
                _scooters.Remove(scooter);
            }
        }
        
        public IList<Scooter> GetScooters()
        {
            return _scooters.ToList();
        }
        
        public Scooter GetScooterById(string scooterId)
        {
            foreach (var scooter in _scooters)
            {
                if (scooter.Id != scooterId) continue;
                return scooter;
            }
            return null;
        }
    }
}
