using System;
using System.Collections.Generic;
using IfScooters.Exceptions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace IfScooters.Tests
{
    [TestClass]
    public class RentalCompanyTests
    {
        [TestMethod]
        public void Name_ValidRentalCompany_XScootersExpected()
        {
            //Arrange
            ScooterService scooterService = new ScooterService();
            RentalAccounting rentalAccounting = new RentalAccounting();
            List<RentedScooters> rentedScooters = new List<RentedScooters>();
            IRentalCompany rentalCompany = new RentalCompany("XScooters", scooterService, rentedScooters, rentalAccounting);
            var expected = "XScooters";
            //Act
            var actual = rentalCompany.Name;
            //Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void StartRent_ValidInput_IsRentedTrueExpected()
        {
            //Arrange
            ScooterService scooterService = new ScooterService();
            RentalAccounting rentalAccounting = new RentalAccounting();
            List<RentedScooters> rentedScooters = new List<RentedScooters>();
            IRentalCompany rentalCompany = new RentalCompany("XScooters", scooterService, rentedScooters, rentalAccounting);
            scooterService.AddScooter("7755", 0.12M);
            var expected1 = true;
            //Act
            rentalCompany.StartRent("7755");
            //Assert
            Assert.AreEqual(expected1, scooterService.GetScooterById("7755").IsRented);
        }

        [TestMethod]
        public void StartRent_Id7755ScooterInput_ValidOutputExpected()
        {
            //Arrange
            ScooterService scooterService = new ScooterService();
            RentalAccounting rentalAccounting = new RentalAccounting();
            List<RentedScooters> rentedScooters = new List<RentedScooters>();
            IRentalCompany rentalCompany = new RentalCompany("XScooters", scooterService, rentedScooters, rentalAccounting);
            scooterService.AddScooter("7755", 0.12M);
            int rentedScooterCount = 1;
            string rentedScooterId = "7755";
            decimal rentedScooterIPricePerMinute = 0.12M;
            bool rentedScooterIdIsRented = true;
            //Act
            rentalCompany.StartRent("7755");
            //Assert
            Assert.AreEqual(rentedScooterCount, rentedScooters.Count);
            Assert.AreEqual(rentedScooterId, rentedScooters[0].Id);
            Assert.AreEqual(rentedScooterIPricePerMinute, rentedScooters[0].PricePerMinute);
            Assert.AreEqual(rentedScooterIdIsRented, rentedScooters[0].IsRented);
        }

        [TestMethod]
        public void StartRent_StartRentWhenAlreadyRented_ScooterRentedExceptionExpected()
        {
            //Arrange
            ScooterService scooterService = new ScooterService();
            RentalAccounting rentalAccounting = new RentalAccounting();
            List<RentedScooters> rentedScooters = new List<RentedScooters>();
            IRentalCompany rentalCompany = new RentalCompany("XScooters", scooterService, rentedScooters, rentalAccounting);
            scooterService.AddScooter("7756", 0.12M);
            rentalCompany.StartRent("7756");
            //Assert
            Assert.ThrowsException<ScooterRentedException>(() => rentalCompany.StartRent("7756"));
        }

        [TestMethod]
        public void EndRent_ValidEndRent_IsRentedFalseExpected()
        {
            //Arrange
            ScooterService scooterService = new ScooterService();
            RentalAccounting rentalAccounting = new RentalAccounting();
            List<RentedScooters> rentedScooters = new List<RentedScooters>();
            IRentalCompany rentalCompany = new RentalCompany("XScooters", scooterService, rentedScooters, rentalAccounting);
            scooterService.AddScooter("7757", 0.12M);
            rentalCompany.StartRent("7757");
            rentalCompany.EndRent("7757");
            rentalCompany.StartRent("7757");
            rentalCompany.EndRent("7757");
            var expected = false;
            //Act
            var actual = scooterService.GetScooterById("7757").IsRented;
            //Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void EndRent_Id7755ScooterInput_ValidOutputExpected()
        {
            //Arrange
            ScooterService scooterService = new ScooterService();
            RentalAccounting rentalAccounting = new RentalAccounting();
            List<RentedScooters> rentedScooters = new List<RentedScooters>();
            IRentalCompany rentalCompany = new RentalCompany("XScooters", scooterService, rentedScooters, rentalAccounting);
            scooterService.AddScooter("7755", 0.12M);
            int rentedScooterCount = 1;
            string rentedScooterId = "7755";
            decimal rentedScooterIPricePerMinute = 0.12M;
            bool rentedScooterIdIsRented = true;
            //Act
            rentalCompany.StartRent("7755");
            rentalCompany.EndRent("7755");
            //Assert
            Assert.AreEqual(rentedScooterCount, rentedScooters.Count);
            Assert.AreEqual(rentedScooterId, rentedScooters[0].Id);
            Assert.AreEqual(rentedScooterIPricePerMinute, rentedScooters[0].PricePerMinute);
            Assert.AreEqual(rentedScooterIdIsRented, rentedScooters[0].IsRented);
        }

        [TestMethod]
        public void EndRent_EndRentWhenRentIsNotStarted_ScooterNotRentedExceptionExpected()
        {
            //Arrange
            ScooterService scooterService = new ScooterService();
            RentalAccounting rentalAccounting = new RentalAccounting();
            List<RentedScooters> rentedScooters = new List<RentedScooters>();
            IRentalCompany rentalCompany = new RentalCompany("XScooters", scooterService, rentedScooters, rentalAccounting);
            scooterService.AddScooter("7758", 0.12M);
            //Assert
            Assert.ThrowsException<ScooterNotRentedException>(() => rentalCompany.EndRent("7758"));
        }

        [DataTestMethod]
        [DataRow(null, false, 21.6)]
        [DataRow(2020, false, 14.4)]
        [DataRow(2021, false, 7.2)]
        [DataRow(null, true, 21.6)]
        [DataRow(2020, true, 14.4)]
        [DataRow(2021, true, 7.2)]
        public void CalculateIncome_(int? year, bool inCludeRented, double income)
        {
            //Arrange
            RentalAccounting rentalAccounting = new RentalAccounting();
            ScooterService scooterService = new ScooterService();
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

            IRentalCompany rentalCompany = new RentalCompany("XScooters", scooterService, rentedScooters, rentalAccounting);

            foreach (var rentedScooter in rentedScooters)
            {
                rentalAccounting.CalculatePrice(rentedScooter);
            }

            var expectedTotalIncome = Convert.ToDecimal(income);
            //Act
            var actual = rentalCompany.CalculateIncome(year, inCludeRented);
            //Assert
            Assert.AreEqual(expectedTotalIncome, actual);
        }
    }
}
