using IfScooters.Exceptions;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IfScooters
{
    public class RentalCompany : IRentalCompany
    {
        private ScooterService _scooterService;
        private List<RentedScooters> _rentedScooters;
        private RentalAccounting _accounting;

        public RentalCompany(string name, ScooterService scooterService, List<RentedScooters> rentedScooters, RentalAccounting accounting)
        {
            Name = name;
            _scooterService = scooterService;
            _rentedScooters = rentedScooters;
            _accounting = accounting;
        }
        public string Name { get; }

        public void StartRent(string id)
        {
            var scooter = _scooterService.GetScooterById(id);
            
            if (!scooter.IsRented)
            {
                scooter.IsRented = true;
                _rentedScooters.Add(new RentedScooters(id, scooter.PricePerMinute, DateTime.Now, true));
            }
            else
            {
                throw new ScooterRentedException("Scooter is not available!");
            }
        }

        public decimal EndRent(string id)
        {
            var scooter = _scooterService.GetScooterById(id);
            RentedScooters rentedScooter;
            if (scooter.IsRented)
            {
                scooter.IsRented = false;
                rentedScooter = _rentedScooters.Find(x => x.Id == id && x.IsRented);
                rentedScooter.IsRented = false;
                rentedScooter.ReturnTime = DateTime.Now;
            }
            else
            {
                throw new ScooterNotRentedException("Scooter is not rented out!");
            }

            decimal price = _accounting.CalculatePrice(rentedScooter);
            return price;
        }

        public decimal CalculateIncome(int? year, bool includeNotCompletedRentals)
        {
            decimal totalIncome = 0;
            totalIncome = _accounting.GetIncome(year);

            if (includeNotCompletedRentals)
            {
                totalIncome += _accounting.GetIncomeFromInRentScooters(_rentedScooters, DateTime.Now);
            }

            return totalIncome;
        }
    }
}
