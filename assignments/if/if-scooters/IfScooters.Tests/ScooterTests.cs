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
            //Act
            var expected = true;
            var actual = scooter.IsRented;
            //Assert
            Assert.AreEqual(expected,actual);
        }

        [TestMethod]
        public void BeingCheckedOut_ExceptionExpected()
        {
            //Arrange
            Scooter scooter = new Scooter("7755", 0.12M);
            var pickTime = new DateTime(2021, 8, 10, 11, 33, 00);
            scooter.BeingCheckedOut(pickTime);
            //Act
            //Assert
            Assert.ThrowsException<ArgumentException>(()=> scooter.BeingCheckedOut(pickTime));
        }

        [TestMethod]
        public void BeingReturned_ExceptionExpected()
        {
            //Arrange
            Scooter scooter = new Scooter("7755", 0.12M);
            var returnTime = new DateTime(2021, 8, 10, 12, 33, 00);
            //Act
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
            //Act
            var expected = false;
            var actual = scooter.IsRented;
            //Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void BeingReturned_DateTime2021810123300_7_2Expected()
        {
            //Arrange
            Scooter scooter = new Scooter("7755", 0.12M);
            var pickTime = new DateTime(2021, 8, 10, 11, 33, 00);
            var returnTime = new DateTime(2021, 8, 10, 12, 33, 00);
            scooter.BeingCheckedOut(pickTime);
            //Act
            var expected = 7.2M;
            var actual = scooter.BeingReturned(returnTime);
            //Assert
            Assert.AreEqual(expected, actual);
        }


        [TestMethod]
        public void CalculatePrice_DateTime2021810123300_7_2Expected()
        {
            //Arrange
            Scooter scooter = new Scooter("7755", 0.12M);
            var pickTime = new DateTime(2021, 8, 10, 11, 33, 00);
            var returnTime = new DateTime(2021, 8, 10, 12, 33, 00);
            scooter.BeingCheckedOut(pickTime);
            //Act
            var expected = 7.2M;
            var actual = scooter.CalculatePrice(returnTime);
            //Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void CalculatePrice_DateTime2021810173300_20Expected()
        {
            //Arrange
            Scooter scooter = new Scooter("7755", 0.12M);
            var pickTime = new DateTime(2021, 8, 10, 11, 33, 00);
            var returnTime = new DateTime(2021, 8, 10, 17, 33, 00);
            scooter.BeingCheckedOut(pickTime);
            //Act
            var expected = 20M;
            var actual = scooter.CalculatePrice(returnTime);
            //Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void CalculatePrice_GivenTime2HoursBetweenSeperateDates_14_4Expected()
        {
            //Arrange
            Scooter scooter = new Scooter("7755", 0.12M);
            var pickTime = new DateTime(2021, 8, 10, 23, 30, 00);
            var returnTime = new DateTime(2021, 8, 11, 1, 30, 00);
            scooter.BeingCheckedOut(pickTime);
            //Act
            var expected = 14.4M;
            var actual = scooter.CalculatePrice(returnTime);
            //Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void CalculatePrice_GivenTime23HoursBetweenSeperateDates_40Expected()
        {
            //Arrange
            Scooter scooter = new Scooter("7755", 0.12M);
            var pickTime = new DateTime(2021, 8, 10, 11, 33, 00);
            var returnTime = new DateTime(2021, 8, 11, 12, 33, 00);
            scooter.BeingCheckedOut(pickTime);
            //Act
            var expected = 40M;
            var actual = scooter.CalculatePrice(returnTime);
            //Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void CalculatePrice_GivenTime5Hours_20Expected()
        {
            //Arrange
            Scooter scooter = new Scooter("7755", 0.12M);
            var pickTime = new DateTime(2021, 8, 10, 11, 33, 00);
            var returnTime = new DateTime(2021, 8, 10, 16, 33, 00);
            scooter.BeingCheckedOut(pickTime);
            //Act
            var expected = 20M;
            var actual = scooter.CalculatePrice(returnTime);
            //Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void CalculatePrice_GivenTime3Days3HoursBetweenSeperateDates_62_8Expected()
        {
            //Arrange
            Scooter scooter = new Scooter("7755", 0.12M);
            var pickTime = new DateTime(2021, 8, 10, 23, 00, 00);
            var returnTime = new DateTime(2021, 8, 13, 02, 10, 00);
            scooter.BeingCheckedOut(pickTime);
            //Act
            var expected = 62.8M;
            var actual = scooter.CalculatePrice(returnTime);
            //Assert
            Assert.AreEqual(expected, actual);
        }
    }
}
