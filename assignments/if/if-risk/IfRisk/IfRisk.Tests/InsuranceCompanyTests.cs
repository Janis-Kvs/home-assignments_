using System;
using System.Collections.Generic;
using System.Net;
using IfRisk.Interfaces;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using IfRisk.Interfaces;

namespace IfRisk.Tests
{
    [TestClass]
    public class InsuranceCompanyTests
    {
        Risk risk1 = new Risk("Water leak in the apartment", 12M);
        Risk risk2 = new Risk("Electricity leakage in the apartment", 12M);

        [TestMethod]
        public void InsuranceCompany_ValidInsuranceCompany_ValidFieldsExpected()
        {
            //Arrange
            List<Risk> risks = new List<Risk> { risk1, risk2 };
            IInsuranceCompany insuranceCompany = new InsuranceCompany("If", risks);
            string expectedName = "If";
            int expectedAvailableRisksListCount = 2;

            //Act
            string actualName = insuranceCompany.Name;
            int actualAvailableRisksListCount = insuranceCompany.AvailableRisks.Count;

            //Assert
            Assert.AreEqual(expectedName, actualName);
            Assert.AreEqual(expectedAvailableRisksListCount, actualAvailableRisksListCount);
        }

        [TestMethod]
        public void SellPolicy_ValidSellPolicy_ValidPolicyFieldsExpected()
        {
            //Arrange
            List<Risk> risks = new List<Risk> { risk1, risk2 };
            IInsuranceCompany insuranceCompany = new InsuranceCompany("If", risks);
            var expectedNameOfInsuredObject = "Juris Berzins";
            var expectedValidFrom = new DateTime(2020, 03, 23);
            var expectedValidTill = new DateTime(2020, 11, 23);
            var expectedPremium = 16M;
            var expectedInsuredRisksCount = 2;

            //Act
            var actualPolicy = insuranceCompany.SellPolicy("Juris Berzins", new DateTime(2020, 03, 23), 8, risks);
          
            //Assert
            Assert.AreEqual(expectedNameOfInsuredObject, actualPolicy.NameOfInsuredObject);
            Assert.AreEqual(expectedValidFrom, actualPolicy.ValidFrom);
            Assert.AreEqual(expectedValidTill, actualPolicy.ValidTill);
            Assert.AreEqual(expectedPremium, actualPolicy.Premium);
            Assert.AreEqual(expectedInsuredRisksCount, actualPolicy.InsuredRisks.Count);
        }

        [TestMethod]
        public void AddRisk_ValidPolicywith2RisksGiven_3RisksExpected()
        {
            //Arrange
            List<Risk> risks = new List<Risk> { risk1, risk2 };
            Risk addedRisk = new Risk("Fire in the apartment", 15M);
            IInsuranceCompany insuranceCompany = new InsuranceCompany("If", risks);
            var policy1 = insuranceCompany.SellPolicy("Juris Berzins", new DateTime(2020, 03, 23), 6, risks);
            int expectedPolicyRiskCount = 3;

            //Act
            insuranceCompany.AddRisk("Juris Berzins", addedRisk, new DateTime(2020, 05, 02));
            int actualPolicyRiskCount = insuranceCompany.GetPolicy("Juris Berzins", new DateTime(2020, 03, 23)).InsuredRisks.Count;
            
            //Assert
            Assert.AreEqual(expectedPolicyRiskCount, actualPolicyRiskCount);
        }

        [TestMethod]
        public void AddRisk_SecondUpdateOfPolicyGiven_4RisksExpected()
        {
            //Arrange
            List<Risk> risks = new List<Risk> { risk1, risk2 };
            Risk addedRisk = new Risk("Fire in the apartment", 15M);
            IInsuranceCompany insuranceCompany = new InsuranceCompany("If", risks);
            var policy1 = insuranceCompany.SellPolicy("Juris Berzins", new DateTime(2020, 03, 23), 6, risks);
            insuranceCompany.AddRisk("Juris Berzins", addedRisk, new DateTime(2020, 05, 02));
            int expectedPolicyRiskCount = 4;

            //Act
            insuranceCompany.AddRisk("Juris Berzins", addedRisk, new DateTime(2020, 06, 02));
            int actualPolicyRiskCount = insuranceCompany.GetPolicy("Juris Berzins", new DateTime(2020, 03, 23)).InsuredRisks.Count;

            //Assert
            Assert.AreEqual(expectedPolicyRiskCount, actualPolicyRiskCount);
        }

        [TestMethod]
        public void GetPolicy_GivenPolicyOf2InitialRisksAndTwoUpdatedRisksandEffectiveDate_4RiskPolicyExpected()
        {
            //Arrange
            List<Risk> risks = new List<Risk> { risk1, risk2 };
            Risk addedRisk = new Risk("Fire in the apartment", 15M);
            IInsuranceCompany insuranceCompany = new InsuranceCompany("If", risks);
            var policy1 = insuranceCompany.SellPolicy("Juris Berzins", new DateTime(2020, 03, 23), 6, risks);
            insuranceCompany.AddRisk("Juris Berzins", addedRisk, new DateTime(2020, 05, 02));
            insuranceCompany.AddRisk("Juris Berzins", addedRisk, new DateTime(2020, 06, 02));
            int expectedPolicyRiskCount = 4;
            string expectedPolicyNameOfInsuredObject = "Juris Berzins";

            //Act
            var actualPolicyRiskCount = insuranceCompany.GetPolicy("Juris Berzins", new DateTime(2020, 03, 23)).InsuredRisks.Count;
            var actualPolicyNameOfInsuredObject = insuranceCompany.GetPolicy("Juris Berzins", new DateTime(2020, 03, 23)).NameOfInsuredObject;

            //Assert
            Assert.AreEqual(expectedPolicyRiskCount, actualPolicyRiskCount);
            Assert.AreEqual(expectedPolicyNameOfInsuredObject, actualPolicyNameOfInsuredObject);
        }
    }
}
