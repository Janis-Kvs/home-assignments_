using System;
using System.Collections.Generic;
using System.Net;
using IfRisk.Interfaces;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using IfRisk.Interfaces;

namespace IfRisk.Tests
{
    [TestClass]
    public class PolicyCalculationTests
    {
        [TestMethod]
        public void CalculatePremium_Given8MonthsAndTwoRisks_16Expected()
        {
            //Arrange
            Risk risk1 = new Risk("Water leak in the apartment", 12M);
            Risk risk2 = new Risk("Electricity leakage in the apartment", 12M);
            IList<Risk> risks = new List<Risk> { risk1, risk2 };
            decimal expectedPremium = 16M;

            //Act
            decimal actualPremium = PolicyCalculations.CalculatePremium(8, risks);

            //Assert
            Assert.AreEqual(expectedPremium, actualPremium);
        }

        [TestMethod]
        public void CalculateValidMonths_Given8MonthsAndTwoRisks_16Expected()
        {
            //Arrange
            decimal expectedMonths = 4;

            //Act
            decimal actualMonths = PolicyCalculations.CalculateValidMonths(new DateTime(2021,02,01), new DateTime(2021,06,12));

            //Assert
            Assert.AreEqual(expectedMonths, actualMonths);
        }
    }
}
