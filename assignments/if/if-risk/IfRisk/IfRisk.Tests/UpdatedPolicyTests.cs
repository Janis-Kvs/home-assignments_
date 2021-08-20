using System;
using System.Collections.Generic;
using System.Net;
using IfRisk.Interfaces;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace IfRisk.Tests
{
    [TestClass]
    public class UpdatedPolicyTests
    {
        [TestMethod]
        public void UpdatedPolicy_ValidUpdatedPolicy_ValidResultsExpected()
        {
            //Arrange
            Risk risk1 = new Risk("Water leak in the apartment", 12M);
            Risk risk2 = new Risk("Electricity leakage in the apartment", 12M);
            Risk addedRisk = new Risk("Fire in the apartment", 15M);
            List<Risk> risks = new List<Risk> { risk1, risk2 };
            IInsuranceCompany insuranceCompany = new InsuranceCompany("If", risks);
            var policy1 = insuranceCompany.SellPolicy("Juris Berzins", new DateTime(2020, 03, 23), 6, risks);
            UpdatedPolicy updatedPolicy = new UpdatedPolicy(policy1, 4, addedRisk, new DateTime(2020, 05, 23));

            string expectedNameOfInsuredObject = "Juris Berzins";
            DateTime expectedValidFrom = new DateTime(2020, 03, 23);
            DateTime expectedValidTill = new DateTime(2020, 09, 23);
            decimal expectedPremium = 17M;
            int expectedInsuredRisksCount = 3;
            decimal expectedAdditionalPremium = 5M;
            DateTime expectedAdditionalValidFrom = new DateTime(2020, 05, 23);
            string expectedAdditionalRiskName = "Fire in the apartment";

            //Act
            string actualNameOfInsuredObject = "Juris Berzins";
            DateTime actualValidFrom = updatedPolicy.ValidFrom;
            DateTime actualValidTill = updatedPolicy.ValidTill;
            decimal actualPremium = updatedPolicy.Premium;
            int actualInsuredRisksCount = updatedPolicy.InsuredRisks.Count;
            decimal actualAdditionalPremium = updatedPolicy.AdditionalPremium;
            DateTime actualAdditionalValidFrom = updatedPolicy.AdditionalValidFrom;
            string actualAdditionalRiskName = updatedPolicy.AdditionalRisk.Name;

            //Assert
            Assert.AreEqual(expectedNameOfInsuredObject, actualNameOfInsuredObject);
            Assert.AreEqual(expectedValidFrom, actualValidFrom);
            Assert.AreEqual(expectedValidTill, actualValidTill);
            Assert.AreEqual(expectedPremium, actualPremium);
            Assert.AreEqual(expectedInsuredRisksCount, actualInsuredRisksCount);
            Assert.AreEqual(expectedAdditionalPremium, actualAdditionalPremium);
            Assert.AreEqual(expectedAdditionalValidFrom, actualAdditionalValidFrom);
            Assert.AreEqual(expectedAdditionalRiskName, actualAdditionalRiskName);
        }
    }
}
