using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace IfScooters.Tests
{
    [TestClass]
    public class ScooterServiceTests
    {
        IScooterService scooterService = new ScooterService();

        [TestMethod]
        public void AddScooter_ValidScooter_Count1Expected()
        {
            //Arrange
            scooterService.AddScooter("7755", 0.12M);
            var expected = 1;
            //Assert
            Assert.IsTrue(scooterService.GetScooters().Count == 1);
        }

        [TestMethod]
        public void RemoveScooter_Remove1From3Scooters_2ScootersExpected()
        {
            //Arrange
            scooterService.AddScooter("7755", 0.12M);
            scooterService.AddScooter("7856", 0.16M);
            scooterService.AddScooter("8888", 0.19M);
            var expected = 2;
            //Act
            scooterService.RemoveScooter("7755");
            var actual = scooterService.GetScooters().Count;
            //Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void RemoveScooter_ArgumentExceptionExpected()
        {
            //Arrange
            scooterService.AddScooter("7755", 0.12M);
            scooterService.AddScooter("7856", 0.16M);
            scooterService.AddScooter("8888", 0.19M);
            scooterService.GetScooterById("7755").IsRented = true;
            //Assert
            Assert.ThrowsException<ArgumentException>(() => scooterService.RemoveScooter("7755"));
        }

        [TestMethod]
        public void GetScooters_Added3Scooters_ListOf3ScootersExpected()
        {
            //Arrange
            scooterService.AddScooter("7755", 0.12M);
            scooterService.AddScooter("7856", 0.16M);
            scooterService.AddScooter("8888", 0.19M);
            var expected = 3;
            //Act
            var actual = scooterService.GetScooters().Count;
            //Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void GetScooterById_ScooterIsExisting_ReturnsScooterIdExpected()
        {
            //Arrange
            scooterService.AddScooter("7755", 0.12M);
            scooterService.AddScooter("7856", 0.16M);
            var expected = "7856";
            //Act
            var actual = scooterService.GetScooterById("7856").Id;
            //Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void GetScooterById_EmptyScooterListGiven_NullExpected()
        {
            //Arrange
            Scooter? expected = null;
            //Act
            var actual = scooterService.GetScooterById("7856");
            //Assert
            Assert.AreEqual(expected, actual);
        }
    }
}
