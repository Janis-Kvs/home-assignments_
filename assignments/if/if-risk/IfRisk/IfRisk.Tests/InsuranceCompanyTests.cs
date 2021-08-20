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
        [TestMethod]
        public void InsuranceCompany_ValidInsuranceCompany_ValidFieldsExpected()
        {
            //Arrange
            Risk risk1 = new Risk("Water leak in the apartment", 12M);
            Risk risk2 = new Risk("Electricity leakage in the apartment", 12M);
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
            Risk risk1 = new Risk("Water leak in the apartment", 10M);
            Risk risk2 = new Risk("Electricity leakage in the apartment", 12M);
            List<Risk> risks = new List<Risk> { risk1, risk2 };
            IInsuranceCompany insuranceCompany = new InsuranceCompany("If", risks);
            var expectedNameOfInsuredObject = "Juris Berzins";
            var expectedValidFrom = new DateTime(2020, 03, 23);
            var expectedValidTill = new DateTime(2020, 11, 23);
            var expectedPremium = 14.67M;
            var expectedInsuredRisksCount = 2;

            //Act
            var actualPolicy = insuranceCompany.SellPolicy("Juris Berzins", new DateTime(2020, 03, 23), 8, risks);
            var actualNameOfInsuredObject = actualPolicy.NameOfInsuredObject;
            var actualValidFrom = actualPolicy.ValidFrom;
            var actualValidTill = actualPolicy.ValidTill;
            var actualPremium = actualPolicy.Premium;
            var actualInsuredRisksCount = actualPolicy.InsuredRisks.Count;


            //Assert
            Assert.AreEqual(expectedNameOfInsuredObject, actualNameOfInsuredObject);
            Assert.AreEqual(expectedValidFrom, actualValidFrom);
            Assert.AreEqual(expectedValidTill, actualValidTill);
            Assert.AreEqual(expectedPremium, actualPremium);
            Assert.AreEqual(expectedInsuredRisksCount, actualInsuredRisksCount);
        }

        [TestMethod]
        public void AddRisk_ValidPolicywith2RisksGiven_3RisksExpected()
        {
            //Arrange
            Risk risk1 = new Risk("Water leak in the apartment", 10M);
            Risk risk2 = new Risk("Electricity leakage in the apartment", 12M);
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
            Risk risk1 = new Risk("Water leak in the apartment", 10M);
            Risk risk2 = new Risk("Electricity leakage in the apartment", 12M);
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
            Risk risk1 = new Risk("Water leak in the apartment", 10M);
            Risk risk2 = new Risk("Electricity leakage in the apartment", 12M);
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
