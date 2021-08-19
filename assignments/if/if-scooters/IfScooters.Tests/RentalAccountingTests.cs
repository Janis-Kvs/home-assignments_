using System;
using System.Collections.Generic;
using System.Diagnostics;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace IfScooters.Tests
{
    [TestClass]
    public class RentalAccountingTests
    {
        [DataTestMethod]
        [DataRow(10, 11, 10, 12, 7.2, 0.12)]
        [DataRow(10, 11, 10, 17, 20, 0.12)]
        [DataRow(10, 23, 11, 1, 14.4, 0.12)]
        [DataRow(10, 11, 11, 12, 40, 0.12)]
        [DataRow(10, 11, 16, 12, 140, 0.12)]
        [DataRow(10, 23, 14, 1, 74.4, 0.12)]
        [DataRow(10, 22, 14, 1, 81.6, 0.12)]
        [DataRow(10, 11, 10, 12, 15, 0.25)]
        [DataRow(10, 11, 10, 17, 20, 0.25)]
        [DataRow(10, 23, 11, 1, 26.75, 0.25)]
        [DataRow(10, 11, 11, 12, 40, 0.25)]
        [DataRow(10, 11, 16, 12, 140, 0.25)]
        [DataRow(10, 23, 14, 1, 86.75, 0.25)]
        [DataRow(10, 22, 14, 0, 88.25, 0.25)]
        [DataRow(6, 12, 7, 12, 40, 1)]
        public void CalculatePriceTests(int day1, int hour1, int day2, int hour2, double price, double pricePerMinute)
        {
            //Arrange
            RentalAccounting rentalAccounting = new RentalAccounting();
            List<RentedScooters> rentedScooters = new List<RentedScooters>();
            rentedScooters.Add(new RentedScooters
            {
                Id = "7711",
                IsRented = false,
                PickTime = new DateTime(2021, 8, day1, hour1, 33, 00),
                PricePerMinute = Convert.ToDecimal(pricePerMinute),
                ReturnTime = new DateTime(2021, 8, day2, hour2, 33, 00)
            });
            
            var expected = Convert.ToDecimal(price);
            //Act
            var actual = rentalAccounting.CalculatePrice(rentedScooters[0]);
            //Assert
            Assert.AreEqual(expected, actual);
        }

        [DataTestMethod]
        [DataRow(null, 21.6)]
        [DataRow(2020, 14.4)]
        [DataRow(2021, 7.2)]
        public void GetIncomeTests(int? year, double income)
        {
            //Arrange
            RentalAccounting rentalAccounting = new RentalAccounting();
            List<RentedScooters> rentedScooters = new List<RentedScooters>
            {
                new RentedScooters
                {
                    Id = "7711",
                    IsRented = false,
                    PickTime = new DateTime(2021, 8, 10, 11, 33, 00),
                    PricePerMinute = 0.12M,
                    ReturnTime = new DateTime(2021, 8, 10, 12, 33, 00)
                },
                new RentedScooters
                {
                    Id = "7722",
                    IsRented = false,
                    PickTime = new DateTime(2020, 8, 10, 11, 33, 00),
                    PricePerMinute = 0.12M,
                    ReturnTime = new DateTime(2020, 8, 10, 13, 33, 00)
                }
            };

            foreach (var rentedScooter in rentedScooters)
            {
                rentalAccounting.CalculatePrice(rentedScooter);
            }

            var totalIncome = Convert.ToDecimal(income);
            //Act
            var actual = rentalAccounting.GetIncome(year);
            //Assert
            Assert.AreEqual(totalIncome, actual);
        }

        [DataTestMethod]
        [DataRow(10, 11, 10, 13, 14.4)]
        [DataRow(10, 11, 11, 13, 40)]
        public void GetIncomeFromInRentScooters(int day1, int hour1, int day2, int hour2, double incomeFromRented)
        {
            //Arrange
            RentalAccounting rentalAccounting = new RentalAccounting();
            List<RentedScooters> rentedScooters = new List<RentedScooters>
            {
                new RentedScooters
                {
                    Id = "7711",
                    IsRented = false,
                    PickTime = new DateTime(2021, 8, 10, 11, 33, 00),
                    PricePerMinute = 0.12M,
                    ReturnTime = new DateTime(2021, 8, 10, 13, 33, 00)
                },
                new RentedScooters
                {
                    Id = "7722",
                    IsRented = true,
                    PickTime = new DateTime(2020, 8, day1, hour1, 33, 00),
                    PricePerMinute = 0.12M,
                    ReturnTime = new DateTime(0001, 01, 01, 00, 00, 00)
                }
            };

            foreach (var rentedScooter in rentedScooters)
            {
                rentalAccounting.CalculatePrice(rentedScooter);
            }

            var totalIncome = Convert.ToDecimal(incomeFromRented);
            //Act
            var actual = rentalAccounting.GetIncomeFromInRentScooters(rentedScooters, new DateTime(2020, 8, day2, hour2, 33, 00));
            //Assert
            Assert.AreEqual(totalIncome, actual);
        }
    }
}
