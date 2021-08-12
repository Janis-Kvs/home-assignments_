using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace IfScooters.Tests
{
    [TestClass]
    public class ScooterTests
    {
        [TestMethod]
        public void Id_ValidScooter_7755Expected()
        {
            //Arrange
            Scooter scooter = new Scooter("7755", 0.12M);
            var expected = "7755";
            //Act
            var actual = scooter.Id;
            //Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void PricePerMinute_ValidScooter_0Point12Expected()
        {
            //Arrange
            Scooter scooter = new Scooter("7755", 0.12M);
            var expected = 0.12M;
            //Act
            var actual = scooter.PricePerMinute;
            //Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void IsRented_ValidScooter_0Point12Expected()
        {
            //Arrange
            Scooter scooter = new Scooter("7755", 0.12M);
            //Act
            var actual = scooter.IsRented;
            //Assert
            Assert.IsFalse(actual);
        }
    }
}
