using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace IfScooters.Tests
{
    [TestClass]
    public class RentalCompanyTests
    {
        RentalCompany rentalCompany = new RentalCompany("XScooters");
        
        [TestMethod]
        public void GetScooterById_ScooterIsExisting_ReturnsScooterIdExpected()
        {
            //Arrange
            rentalCompany.AddScooter("7755", 0.12M);
            rentalCompany.AddScooter("7856", 0.16M);
            var expected = "7856";
            //Act
            var actual = rentalCompany.GetScooterById("7856").Id;
            //Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void GetPriceFromRentedScooters_1HourRentTimeGiven_Price7Point2Expected()
        {
            //Arrange
            rentalCompany.AddScooter("7755", 0.12M);
            rentalCompany.AddScooter("7856", 0.16M);
            rentalCompany.StartRent("7755", new DateTime(2021, 8, 10, 11, 33, 00));
            var expected = 7.2M;
            //Act
            var actual = rentalCompany.GetPriceFromRentedScooters(new DateTime(2021, 8, 10, 12, 33, 00));
            //Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void GetScooters_Given2Available1RentedScooter_2AvailableScootersExpected()
        {
            //Arrange
            rentalCompany.AddScooter("7755", 0.12M);
            rentalCompany.AddScooter("7856", 0.16M);
            rentalCompany.AddScooter("8888", 0.19M);
            rentalCompany.StartRent("7755", new DateTime(2021, 8, 10, 11, 33, 00));
            var expected = 2;
            //Act
            var actual = rentalCompany.GetScooters().Count;
            //Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void EndRent_Given2HourRentTime_Price14Point4Expected()
        {
            //Arrange
            rentalCompany.AddScooter("7755", 0.12M);
            rentalCompany.AddScooter("7856", 0.16M);
            rentalCompany.AddScooter("8888", 0.19M);
            rentalCompany.StartRent("7755", new DateTime(2021, 8, 10, 11, 33, 00));
            var expected = 14.4M;
            //Act
            var actual = rentalCompany.EndRent("7755", new DateTime(2021, 8, 10, 13, 33, 00));
            //Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void RemoveScooter_Remove1From3Scooters_2AvailableScootersExpected()
        {
            //Arrange
            rentalCompany.AddScooter("7755", 0.12M);
            rentalCompany.AddScooter("7856", 0.16M);
            rentalCompany.AddScooter("8888", 0.19M);
            var expected = 2;
            //Act
            rentalCompany.RemoveScooter("7755");
            var actual = rentalCompany.GetScooters().Count;
            //Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void RemoveScooter_ArgumentExceptionExpected()
        {
            //Arrange
            rentalCompany.AddScooter("7755", 0.12M);
            rentalCompany.AddScooter("7856", 0.16M);
            rentalCompany.AddScooter("8888", 0.19M);
            rentalCompany.StartRent("7755", new DateTime(2021, 8, 10, 11, 33, 00));
            //Assert
            Assert.ThrowsException<ArgumentException>(() => rentalCompany.RemoveScooter("7755"));
        }

        [TestMethod]
        public void EndRent_RentTime1HourFor7856ScooterId_Price9Point6Expected()
        {
            //Arrange
            rentalCompany.AddScooter("7755", 0.12M);
            rentalCompany.AddScooter("7856", 0.16M);
            rentalCompany.StartRent("7856", new DateTime(2021, 8, 10, 11, 33, 00));
            var expected = 9.6M;
            //Act
            var actual = rentalCompany.EndRent("7856", new DateTime(2021, 8, 10, 12, 33, 00));
            //Assert
            Assert.AreEqual(expected, actual);
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
            rentalCompany.AddScooter("7711", 0.12M);
            rentalCompany.AddScooter("7722", 0.16M);

            rentalCompany.StartRent("7711", new DateTime(2020, 8, 10, 11, 33, 00));
            rentalCompany.EndRent("7711", new DateTime(2020, 8, 10, 12, 33, 00));

            rentalCompany.StartRent("7722", new DateTime(2021, 8, 10, 11, 33, 00));
            rentalCompany.EndRent("7722", new DateTime(2021, 8, 10, 12, 33, 00));

            rentalCompany.StartRent("7722", new DateTime(2021, 8, 10, 13, 33, 00));
            var expected = Convert.ToDecimal(income);
            //Act
            var actual = rentalCompany.CalculateIncome(year, rented, new DateTime(2021, 8, 10, 15, 33, 00));
            //Assert
            Assert.AreEqual(expected, actual);
        }
    }
}
