using System;

namespace IfRisk
{
    public struct Risk
    {
        public Risk(string name, decimal yearlyPrice)
        {
            Name = name;
            YearlyPrice = yearlyPrice;
        }
        /// <summary>
        /// Unique name of the risk
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// Risk yearly price
        /// </summary>
        public decimal YearlyPrice { get; set; }
    }
}
