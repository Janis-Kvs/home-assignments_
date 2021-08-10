using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IfScooters
{
    public class RentalCompany : IRentalCompany, IScooterService
    {
        private List<Scooter> _scooters;
        private Dictionary<int, decimal> _income;
        public RentalCompany(string name)
        {
            Name = name;
            _income = new Dictionary<int, decimal>();
            _scooters = new List<Scooter>();
        }
        
        public string Name { get; }

        public void AddScooter(string id, decimal pricePerMinute)
        {
            _scooters.Add(new Scooter(id, pricePerMinute));
        }

        public void RemoveScooter(string id)
        {
            var scooter = GetScooterById(id);
            if (scooter.IsRented)
            {
                throw new ArgumentException("Cannot remove rented scooter!");
            }
            else
            {
                _scooters.Remove(scooter);
            }
        }

        public void StartRent(string id, DateTime pickTime)
        {
            var scooter = GetScooterById(id);
            scooter?.BeingCheckedOut(pickTime);
        }

        public decimal EndRent(string id, DateTime returnTime)
        {
            var scooter = GetScooterById(id);
            decimal price = scooter.BeingReturned(returnTime);
            if (_income.ContainsKey(returnTime.Year))
            {
                _income[returnTime.Year] += price;
            }
            else
            {
                _income.Add(returnTime.Year, price);
            }

            return price;
        }

        public IList<Scooter> GetScooters()
        {
            IList<Scooter> availableScooters = new List<Scooter>();
            foreach (var scooter in _scooters)
            {
                if (!scooter.IsRented)
                {
                    availableScooters.Add(scooter);
                }
            }
            return availableScooters;
        }

       public decimal CalculateIncome(int? year, bool includeNotCompletedRentals, DateTime returnTime)
        {
            decimal totalIncome = 0;

            if (year != null)
            { 
                _income.TryGetValue(Convert.ToInt32(year), out totalIncome);
            }
            else
            {
                foreach (var incomeYear in _income)
                {
                    decimal yearIncome = incomeYear.Value;
                    totalIncome += yearIncome;
                }
            }

            if (includeNotCompletedRentals)
            {
                totalIncome += GetPriceFromRentedScooters(returnTime);
            }

            return totalIncome;
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

        public decimal GetPriceFromRentedScooters(DateTime returnTime)
        {
            decimal incomeFromRented = 0;
            foreach (var scooter in _scooters)
            {
                if (!scooter.IsRented) continue;
                incomeFromRented += scooter.CalculatePrice(returnTime);
            }
            return incomeFromRented;
        }
    }
}
