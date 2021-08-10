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
        public void GetScooterById_7856Given_7856Expected()
        {
            //Arrange
            rentalCompany.AddScooter("7755", 0.12M);
            rentalCompany.AddScooter("7856", 0.16M);
            //Act
            var expected = "7856";
            var actual = rentalCompany.GetScooterById("7856").Id;
            //Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void GetPriceFromRentedScooters_Given1HourRentTime_7_2Expected()
        {
            //Arrange
            rentalCompany.AddScooter("7755", 0.12M);
            rentalCompany.AddScooter("7856", 0.16M);
            rentalCompany.StartRent("7755", new DateTime(2021, 8, 10, 11, 33, 00));
            //Act
            var expected = 7.2M;
            var actual = rentalCompany.GetPriceFromRentedScooters(new DateTime(2021, 8, 10, 12, 33, 00));
            //Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void GetScooters_Given3scooters_2Expected()
        {
            //Arrange
            rentalCompany.AddScooter("7755", 0.12M);
            rentalCompany.AddScooter("7856", 0.16M);
            rentalCompany.AddScooter("8888", 0.19M);
            rentalCompany.StartRent("7755", new DateTime(2021, 8, 10, 11, 33, 00));
            //Act
            var expected = 2;
            var actual = rentalCompany.GetScooters().Count;
            //Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void EndRent_Given2HourRentTime_14_4Expected()
        {
            //Arrange
            rentalCompany.AddScooter("7755", 0.12M);
            rentalCompany.AddScooter("7856", 0.16M);
            rentalCompany.AddScooter("8888", 0.19M);
            rentalCompany.StartRent("7755", new DateTime(2021, 8, 10, 11, 33, 00));
            //Act
            var expected = 14.4M;
            var actual = rentalCompany.EndRent("7755", new DateTime(2021, 8, 10, 13, 33, 00));
            //Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void RemoveScooter_Given3Scooters_2Expected()
        {
            //Arrange
            rentalCompany.AddScooter("7755", 0.12M);
            rentalCompany.AddScooter("7856", 0.16M);
            rentalCompany.AddScooter("8888", 0.19M);
            //Act
            var expected = 2;
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
        public void EndRent_7856Given_7856Expected()
        {
            //Arrange
            rentalCompany.AddScooter("7755", 0.12M);
            rentalCompany.AddScooter("7856", 0.16M);
            rentalCompany.StartRent("7856", new DateTime(2021, 8, 10, 11, 33, 00));
            //Act
            var expected = 9.6M;
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

            //Act
            var expected = Convert.ToDecimal(income);
            var actual = rentalCompany.CalculateIncome(year, rented, new DateTime(2021, 8, 10, 15, 33, 00));
            //Assert
            Assert.AreEqual(expected, actual);
        }
    }
}
