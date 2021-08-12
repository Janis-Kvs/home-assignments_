using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace IfScooters.Tests
{
    [TestClass]
    public class RentalCompanyTests
    {
        IRentalCompany rentalCompany = new RentalCompany("XScooters");
        ScooterService scooterService = new ScooterService();

        [TestMethod]
        public void Name_ValidRentalCompany_XScootersExpected()
        {
            //Arrange
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
            scooterService.AddScooter("7755", 0.12M);
            var expected1 = true;
            //Act
            rentalCompany.StartRent("7755", new DateTime(2021, 8, 10, 11, 33, 00), scooterService);
            //Assert
            Assert.AreEqual(expected1, scooterService.GetScooterById("7755").IsRented);
        }

        [TestMethod]
        public void StartRent_StartRentWhenAlreadyRented_ExceptionExpected()
        {
            //Arrange
            scooterService.AddScooter("7755", 0.12M);
            rentalCompany.StartRent("7755", new DateTime(2021, 8, 10, 11, 33, 00), scooterService);
            //Assert
            Assert.ThrowsException<InvalidOperationException>(() => rentalCompany.StartRent("7755", new DateTime(2021, 8, 10, 11, 33, 00), scooterService));
        }

        [TestMethod]
        public void EndRent_Given2HourRentTime_Price14Point4Expected()
        {
            //Arrange
            scooterService.AddScooter("7755", 0.12M);
            scooterService.AddScooter("7856", 0.16M);
            scooterService.AddScooter("8888", 0.19M);
            rentalCompany.StartRent("7755", new DateTime(2021, 8, 10, 11, 33, 00), scooterService);
            rentalCompany.EndRent("7755", new DateTime(2021, 8, 10, 13, 33, 00), scooterService);
            rentalCompany.StartRent("7755", new DateTime(2021, 8, 10, 14, 33, 00), scooterService);
            var expected1 = 14.4M;
            var expected2 = false;
            //Act
            var actual1 = rentalCompany.EndRent("7755", new DateTime(2021, 8, 10, 16, 33, 00), scooterService);
            var actual2 = scooterService.GetScooterById("7755").IsRented;
            //Assert
            Assert.AreEqual(expected1, actual1);
            Assert.AreEqual(expected2, actual2);
        }

        [TestMethod]
        public void EndRent_EndRentWhenRentIsNotStarted_ExceptionExpected()
        {
            //Arrange
            scooterService.AddScooter("7755", 0.12M);
            //Assert
            Assert.ThrowsException<InvalidOperationException>(() => rentalCompany.EndRent("7755", new DateTime(2021, 8, 10, 11, 33, 00), scooterService));
        }

        [DataTestMethod]
        [DataRow(null, true, 36)]
        [DataRow(null, false, 16.8)]
        [DataRow(2020, true, 26.4)]
        [DataRow(2020, false, 7.2)]
        [DataRow(2021, true, 28.8)]
        [DataRow(2021, false, 9.6)]
        public void CalculateIncomeTests(int? year, bool rented, double income)
        {
            //Arrange
            scooterService.AddScooter("7711", 0.12M);
            scooterService.AddScooter("7722", 0.16M);

            rentalCompany.StartRent("7711", new DateTime(2020, 8, 10, 11, 33, 00), scooterService);
            rentalCompany.EndRent("7711", new DateTime(2020, 8, 10, 12, 33, 00), scooterService);

            rentalCompany.StartRent("7722", new DateTime(2021, 8, 10, 11, 33, 00), scooterService);
            rentalCompany.EndRent("7722", new DateTime(2021, 8, 10, 12, 33, 00), scooterService);

            rentalCompany.StartRent("7722", new DateTime(2021, 8, 10, 13, 33, 00), scooterService);
            var expected = Convert.ToDecimal(income);
            //Act
            var actual = rentalCompany.CalculateIncome(year, rented, new DateTime(2021, 8, 10, 15, 33, 00), scooterService);
            //Assert
            Assert.AreEqual(expected, actual);
        }

        [DataTestMethod]
        [DataRow(10, 11, 10, 12, 7.2)]
        [DataRow(10, 11, 10, 17, 20)]
        [DataRow(10, 23, 11, 1, 14.4)]
        [DataRow(10, 11, 11, 12, 40)]
        [DataRow(10, 11, 16, 12, 140)]
        [DataRow(10, 23, 14, 1, 74.4)]
        [DataRow(10, 22, 14, 1, 81.6)]
        public void CalculatePriceTests(int day1, int hour1, int day2, int hour2, double price)
        {
            //Arrange
            RentalCompany rentalCompany = new RentalCompany("XScooters");
            scooterService.AddScooter("7711", 0.12M);
            rentalCompany.StartRent("7711", new DateTime(2020, 8, day1, hour1, 33, 00), scooterService);
            var expected = Convert.ToDecimal(price);
            var scooter = scooterService.GetScooterById("7711");
            //Act
            var actual = rentalCompany.CalculatePrice(scooter, new DateTime(2020, 8, day2, hour2, 33, 00));
            //Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void GetPriceFromRentedScooters_1HourRentTimeGiven_Price7Point2Expected()
        {
            //Arrange
            RentalCompany rentalCompany = new RentalCompany("XScooters");
            scooterService.AddScooter("7755", 0.12M);
            scooterService.AddScooter("7856", 0.16M);
            rentalCompany.StartRent("7755", new DateTime(2021, 8, 10, 11, 33, 00), scooterService);
            var scooters = scooterService.GetScooters();
            var expected = 7.2M;
            //Act
            var actual = rentalCompany.GetPriceFromRentedScooters(new DateTime(2021, 8, 10, 12, 33, 00), scooters);
            //Assert
            Assert.AreEqual(expected, actual);
        }
    }
}
