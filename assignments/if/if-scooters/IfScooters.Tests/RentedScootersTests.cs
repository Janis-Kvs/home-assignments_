using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace IfScooters.Tests
{
    [TestClass]
    public class RentedScootersTests
    {
        private IRentedScooters renedScooter =
            new RentedScooters("7755", 0.12M, new DateTime(2021, 02, 12, 12, 12, 12), true);
        [TestMethod]
        public void Id_ValidRentedScooter_7755Expected()
        {
            //Arrange
            var expected = "7755";
            //Act
            var actual = renedScooter.Id;
            //Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void PricePerMinute_ValidRentedScooter_0Point12Expected()
        {
            //Arrange
            var expected = 0.12M;
            //Act
            var actual = renedScooter.PricePerMinute;
            //Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void PickTime_ValidRentedScooter_20210212121212DateTimeExpected()
        {
            //Arrange
            var expected = new DateTime(2021, 02, 12, 12, 12, 12);
            //Act
            var actual = renedScooter.PickTime;
            //Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void ReturnTime_ValidRentedScooter_DateTimeMinValueExpected()
        {
            //Arrange
            var expected = DateTime.MinValue;
            //Act
            var actual = renedScooter.ReturnTime;
            //Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void IsRented_ValidScooter_0Point12Expected()
        {
            //Act
            var actual = renedScooter.IsRented;
            //Assert
            Assert.IsTrue(actual);
        }
    }
}
