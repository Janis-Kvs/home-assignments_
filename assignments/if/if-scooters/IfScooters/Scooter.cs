using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IfScooters
{
    public class Scooter
    {
        private bool _available;
        private DateTime _pickTime;
        private decimal _price;

        public Scooter(string id, decimal pricePerMinute)
        {
            Id = id;
            PricePerMinute = pricePerMinute;
            _available = true;
        }
        
        public string Id { get; }
        
        public decimal PricePerMinute { get; }

        public bool IsRented
        {
            get { return !_available; }
        }

        public void BeingCheckedOut(DateTime time)
        {
            if (_available)
            {
                _available = false;
                _pickTime = time;
            }
            else
            {
                throw new ArgumentException("Scooter is not available!");
            }
        }
        public decimal BeingReturned(DateTime returnTime)
        {
            if (!_available)
            {
                _available = true;
                CalculatePrice(returnTime);
            }
            else
            {
                throw new ArgumentException("Scooter is not rented out!");
            }
            return _price;
        }

        public decimal CalculatePrice(DateTime returnT)
        {
            TimeSpan rentTime = returnT - _pickTime;
            decimal pickDay = _pickTime.Day;
            decimal returnDay = returnT.Day;
            decimal rentDays = returnDay - pickDay;
            decimal initialPrice = (decimal)rentTime.TotalMinutes * PricePerMinute;

            if (pickDay == returnDay && initialPrice <= 20)
            {
                _price = initialPrice;
            }

            if (pickDay == returnDay && initialPrice > 20)
            {
                _price = 20;
            }

            if (pickDay != returnDay && initialPrice <= 20)
            {
                _price = initialPrice;
            }

            if (pickDay != returnDay && initialPrice > 20)
            {
                decimal firstDayMinutes = 1440 - _pickTime.Hour * 60 + _pickTime.Minute;
                decimal initialFirstDayPrice = firstDayMinutes * PricePerMinute;
                decimal firstDayPrice = (initialFirstDayPrice <= 20) ? initialFirstDayPrice : 20;

                decimal middleDayPrice = (rentDays - 1) * 20;

                decimal lastDayMinutes = returnT.Hour * 60 + returnT.Minute;
                decimal initialLastDayPrice = lastDayMinutes * PricePerMinute;
                decimal LastDayPrice = (initialLastDayPrice <= 20) ? initialLastDayPrice : 20;

                _price = firstDayPrice + middleDayPrice + LastDayPrice;
            }

            return _price;
        }
    }
}
