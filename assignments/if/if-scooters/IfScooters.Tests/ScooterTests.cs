using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace IfScooters.Tests
{
    [TestClass]
    public class ScooterTests
    {
        [TestMethod]
        public void BeingCheckedOut_IsRented_TrueExpected()
        {
            //Arrange
            Scooter scooter = new Scooter("7755", 0.12M);
            var pickTime = new DateTime(2021, 8, 10, 11, 33, 00);
            scooter.BeingCheckedOut(pickTime);
            var expected = true;
            //Act
            var actual = scooter.IsRented;
            //Assert
            Assert.AreEqual(expected,actual);
        }

        [TestMethod]
        public void BeingCheckedOut_ScooterIsAlreadyRented_ExceptionExpected()
        {
            //Arrange
            Scooter scooter = new Scooter("7755", 0.12M);
            var pickTime = new DateTime(2021, 8, 10, 11, 33, 00);
            scooter.BeingCheckedOut(pickTime);
            //Assert
            Assert.ThrowsException<ArgumentException>(()=> scooter.BeingCheckedOut(pickTime));
        }

        [TestMethod]
        public void BeingReturned_ScooterIsNotRentedYet_ExceptionExpected()
        {
            //Arrange
            Scooter scooter = new Scooter("7755", 0.12M);
            var returnTime = new DateTime(2021, 8, 10, 12, 33, 00);
            //Assert
            Assert.ThrowsException<ArgumentException>(() => scooter.BeingReturned(returnTime));
        }

        [TestMethod]
        public void BeingReturned_IsRented_FalseExpected()
        {
            //Arrange
            Scooter scooter = new Scooter("7755", 0.12M);
            var pickTime = new DateTime(2021, 8, 10, 11, 33, 00);
            var returnTime = new DateTime(2021, 8, 10, 12, 33, 00);
            scooter.BeingCheckedOut(pickTime);
            scooter.BeingReturned(returnTime);
            var expected = false;
            //Act
            var actual = scooter.IsRented;
            //Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void BeingReturned_Given1HourRentTime_Price7Point2Expected()
        {
            //Arrange
            Scooter scooter = new Scooter("7755", 0.12M);
            var pickTime = new DateTime(2021, 8, 10, 11, 33, 00);
            var returnTime = new DateTime(2021, 8, 10, 12, 33, 00);
            scooter.BeingCheckedOut(pickTime);
            var expected = 7.2M;
            //Act
            var actual = scooter.BeingReturned(returnTime);
            //Assert
            Assert.AreEqual(expected, actual);
        }


        [TestMethod]
        public void CalculatePrice_Given1HourRentTime_Price7Point2Expected()
        {
            //Arrange
            Scooter scooter = new Scooter("7755", 0.12M);
            var pickTime = new DateTime(2021, 8, 10, 11, 33, 00);
            var returnTime = new DateTime(2021, 8, 10, 12, 33, 00);
            scooter.BeingCheckedOut(pickTime);
            var expected = 7.2M;
            //Act
            var actual = scooter.CalculatePrice(returnTime);
            //Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void CalculatePrice_Given6HoursRentTime_Price20Expected()
        {
            //Arrange
            Scooter scooter = new Scooter("7755", 0.12M);
            var pickTime = new DateTime(2021, 8, 10, 11, 33, 00);
            var returnTime = new DateTime(2021, 8, 10, 17, 33, 00);
            scooter.BeingCheckedOut(pickTime);
            var expected = 20M;
            //Act
            var actual = scooter.CalculatePrice(returnTime);
            //Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void CalculatePrice_GivenRentTime2HoursBetweenSeperateDates_Price14Point4Expected()
        {
            //Arrange
            Scooter scooter = new Scooter("7755", 0.12M);
            var pickTime = new DateTime(2021, 8, 10, 23, 30, 00);
            var returnTime = new DateTime(2021, 8, 11, 1, 30, 00);
            scooter.BeingCheckedOut(pickTime);
            var expected = 14.4M;
            //Act
            var actual = scooter.CalculatePrice(returnTime);
            //Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void CalculatePrice_GivenRentTime23HoursBetweenSeperateDates_Price40Expected()
        {
            //Arrange
            Scooter scooter = new Scooter("7755", 0.12M);
            var pickTime = new DateTime(2021, 8, 10, 11, 33, 00);
            var returnTime = new DateTime(2021, 8, 11, 12, 33, 00);
            scooter.BeingCheckedOut(pickTime);
            var expected = 40M;
            //Act
            var actual = scooter.CalculatePrice(returnTime);
            //Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void CalculatePrice_GivenRentTime5Hours_Price20Expected()
        {
            //Arrange
            Scooter scooter = new Scooter("7755", 0.12M);
            var pickTime = new DateTime(2021, 8, 10, 11, 33, 00);
            var returnTime = new DateTime(2021, 8, 10, 16, 33, 00);
            scooter.BeingCheckedOut(pickTime);
            var expected = 20M;
            //Act
            var actual = scooter.CalculatePrice(returnTime);
            //Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void CalculatePrice_GivenRentTime3Days3HoursBetweenSeperateDates_Price62Point8Expected()
        {
            //Arrange
            Scooter scooter = new Scooter("7755", 0.12M);
            var pickTime = new DateTime(2021, 8, 10, 23, 00, 00);
            var returnTime = new DateTime(2021, 8, 13, 02, 10, 00);
            scooter.BeingCheckedOut(pickTime);
            var expected = 62.8M;
            //Act
            var actual = scooter.CalculatePrice(returnTime);
            //Assert
            Assert.AreEqual(expected, actual);
        }
    }
}
