using System;
using System.Collections.Generic;
using System.Net;
using IfRisk.Interfaces;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace IfRisk.Tests
{
    [TestClass]
    public class PolicyTests
    {
        [TestMethod]
        public void Policy_ValidPolicy_ValidResultsExpected()
        {
            //Arrange
            Risk risk1 = new Risk("Water leak in the apartment", 12M);
            Risk risk2 = new Risk("Electricity leakage in the apartment", 12M);
            List<Risk> risks = new List<Risk> { risk1, risk2 };
            IPolicy policy = new Policy("Juris Berzins", 
                new DateTime(2020, 1, 10), 
                new DateTime(2020, 10, 20), 
                20M,
                risks);
           
            string nameOfInsuredObject = "Juris Berzins";
            DateTime validFrom = new DateTime(2020, 1, 10);
            DateTime validTill = new DateTime(2020, 10, 20);
            decimal premium = 20M;
            int insuredRisksCount = 2;
            //Act
          
            //Assert
            Assert.AreEqual(nameOfInsuredObject, policy.NameOfInsuredObject);
            Assert.AreEqual(validFrom, policy.ValidFrom);
            Assert.AreEqual(validTill, policy.ValidTill);
            Assert.AreEqual(premium, policy.Premium);
            Assert.AreEqual(insuredRisksCount, policy.InsuredRisks.Count);
        }
    }
}
