using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace IfRisk.Tests
{
    [TestClass]
    public class RiskTests
    {
        [TestMethod]
        public void Risk_ValidRisk_ValidNameAndYearlyPriceExpected()
        {
            //Arrange
            Risk risk = new Risk("Water leak in the apartment", 12M);
            string riskName = "Water leak in the apartment";
            decimal yearlyPrice = 12M;
            //Act
            string actualRiskName = risk.Name;
            decimal actualYearlyPrice = risk.YearlyPrice;
            //Assert
            Assert.AreEqual(riskName, actualRiskName);
            Assert.AreEqual(yearlyPrice, actualYearlyPrice);
        }
    }
}
