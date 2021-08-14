using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace IfScooters.Tests
{
    [TestClass]
    public class ScooterTests
    {
        Scooter scooter = new Scooter("7755", 0.12M);
        [TestMethod]
        public void Id_ValidScooter_7755Expected()
        {
            //Arrange
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
            var expected = 0.12M;
            //Act
            var actual = scooter.PricePerMinute;
            //Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void IsRented_ValidScooter_0Point12Expected()
        {
            //Act
            var actual = scooter.IsRented;
            //Assert
            Assert.IsFalse(actual);
        }
    }
}
