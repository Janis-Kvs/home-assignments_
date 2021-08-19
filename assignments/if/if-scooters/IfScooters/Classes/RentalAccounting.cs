using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IfScooters
{
    public class RentalAccounting : IRentalAccounting
    {
        private Dictionary<int, decimal> _income;

        public RentalAccounting()
        {
            _income = new Dictionary<int, decimal>();
        }

        public decimal CalculatePrice(RentedScooters rentedScooter)
        {
            var pickTime = rentedScooter.PickTime;
            var returnTime = rentedScooter.ReturnTime;
            var pricePerMinute = rentedScooter.PricePerMinute;
            decimal price = 0;
            TimeSpan rentTime = returnTime - pickTime;
            decimal pickDay = pickTime.Day;
            decimal returnDay = returnTime.Day;
            decimal rentDays = returnDay - pickDay;
            decimal initialPrice = (decimal)rentTime.TotalMinutes * pricePerMinute;

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
                decimal firstDayMinutes = 1440 - pickTime.Hour * 60 - pickTime.Minute;
                decimal initialFirstDayPrice = firstDayMinutes * pricePerMinute;
                decimal firstDayPrice = (initialFirstDayPrice <= 20) ? initialFirstDayPrice : 20;

                decimal middleDayPrice = (rentDays - 1) * 20;

                decimal lastDayMinutes = returnTime.Hour * 60 + returnTime.Minute;
                decimal initialLastDayPrice = lastDayMinutes * pricePerMinute;
                decimal LastDayPrice = (initialLastDayPrice <= 20) ? initialLastDayPrice : 20;

                price = firstDayPrice + middleDayPrice + LastDayPrice;
            }

            AddIncome(price, rentedScooter);
            return price;
        }

        void AddIncome(decimal price, RentedScooters rentedScooter)
        {
            if (_income.ContainsKey(rentedScooter.ReturnTime.Year))
            {
                _income[rentedScooter.ReturnTime.Year] += price;
            }
            else
            {
                _income.Add(rentedScooter.ReturnTime.Year, price);
            }
        }

        public decimal GetIncome(int? year)
        {
            decimal totalIncome = 0;
            if (year is null)
            {
                foreach (var incomeYear in _income)
                {
                    decimal yearIncome = incomeYear.Value;
                    totalIncome += yearIncome;
                }
            }
            else
            {
                totalIncome = _income[Convert.ToInt32(year)];
            }

            return totalIncome;
        }

        public decimal GetIncomeFromInRentScooters(List<RentedScooters> rentedScooters, DateTime incomeTime)
        {
            decimal incomeFromRented = 0;
            var inRentScooters = rentedScooters.Where(x => x.IsRented == true).Select(x => { x.ReturnTime = incomeTime; return x; }).ToList();
            foreach (var inRentScooter in inRentScooters)
            {
                incomeFromRented += CalculatePrice(inRentScooter);
            }
            return incomeFromRented;
        }
    }
}
