using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IfScooters
{
    public class RentalCompany : IRentalCompany
    {
        private Dictionary<int, decimal> _income;
        private Dictionary<string, DateTime> _pickTime;

        public RentalCompany(string name)
        {
            Name = name;
            _income = new Dictionary<int, decimal>();
            _pickTime = new Dictionary<string, DateTime>();
        }
        public string Name { get; }

        public void StartRent(string id, DateTime pickTime, ScooterService scooterService)
        {
            var scooter = scooterService.GetScooterById(id);
           
            if (!scooter.IsRented)
            {
                scooter.IsRented = true;
                AddPickTime(pickTime, scooter);
            }
            else
            {
                throw new InvalidOperationException("Scooter is not available!");
            }
        }

        public decimal EndRent(string id, DateTime returnTime, ScooterService scooterService)
        {
            var scooter = scooterService.GetScooterById(id);

            if (scooter.IsRented)
            {
                scooter.IsRented = false;
            }
            else
            {
                throw new InvalidOperationException("Scooter is not rented out!");
            }

            decimal price = CalculatePrice(scooter, returnTime);
            AddIncome(price, returnTime);
        
            return price;
        }

        public decimal CalculateIncome(int? year, bool includeNotCompletedRentals, DateTime incomeTime, ScooterService scooterService)
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
                IList<Scooter> scooters = scooterService.GetScooters();
                totalIncome += GetPriceFromRentedScooters(incomeTime, scooters);
            }

            return totalIncome;
        }

        public decimal GetPriceFromRentedScooters(DateTime incomeTime, IList<Scooter> scooters)
        {
            decimal incomeFromRented = 0;
            foreach (var scooter in scooters)
            {
                if (scooter.IsRented)
                {
                    incomeFromRented += CalculatePrice(scooter, incomeTime);
                }
            }
            return incomeFromRented;
        }

        public decimal CalculatePrice(Scooter scooter, DateTime returnTime)
        {
            decimal price = 0;
            TimeSpan rentTime = returnTime - _pickTime[scooter.Id];
            decimal pickDay = _pickTime[scooter.Id].Day;
            decimal returnDay = returnTime.Day;
            decimal rentDays = returnDay - pickDay;
            decimal initialPrice = (decimal)rentTime.TotalMinutes * scooter.PricePerMinute;

            if (pickDay == returnDay && initialPrice <= 20)
            {
                price = initialPrice;
            }
            else if (pickDay == returnDay && initialPrice > 20)
            {
                price = 20;
            }
            else if (pickDay != returnDay && initialPrice <= 20)
            {
                price = initialPrice;
            }
            else if (pickDay != returnDay && initialPrice > 20)
            {
                decimal firstDayMinutes = 1440 - _pickTime[scooter.Id].Hour * 60 - _pickTime[scooter.Id].Minute;
                decimal initialFirstDayPrice = firstDayMinutes * scooter.PricePerMinute;
                decimal firstDayPrice = (initialFirstDayPrice <= 20) ? initialFirstDayPrice : 20;

                decimal middleDayPrice = (rentDays - 1) * 20;

                decimal lastDayMinutes = returnTime.Hour * 60 + returnTime.Minute;
                decimal initialLastDayPrice = lastDayMinutes * scooter.PricePerMinute;
                decimal LastDayPrice = (initialLastDayPrice <= 20) ? initialLastDayPrice : 20;

                price = firstDayPrice + middleDayPrice + LastDayPrice;
            }

            return price;
        }

        void AddPickTime(DateTime pickTime, Scooter scooter)
        {
            if (_pickTime.ContainsKey(scooter.Id))
            {
                _pickTime[scooter.Id] = pickTime;
            }
            else
            {
                _pickTime.Add(scooter.Id, pickTime);
            }
        }

        void AddIncome(decimal price, DateTime returnTime)
        {
            if (_income.ContainsKey(returnTime.Year))
            {
                _income[returnTime.Year] += price;
            }
            else
            {
                _income.Add(returnTime.Year, price);
            }
        }
    }
}
