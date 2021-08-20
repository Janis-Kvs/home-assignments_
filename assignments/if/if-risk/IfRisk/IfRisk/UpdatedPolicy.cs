using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IfRisk.Interfaces;

namespace IfRisk
{
    public class UpdatedPolicy : IPolicy
    {
        public UpdatedPolicy(IPolicy previousPolicy, short validMonths, Risk addedRisk, DateTime additionalValidFrom)
        {
            NameOfInsuredObject = previousPolicy.NameOfInsuredObject;
            ValidFrom = previousPolicy.ValidFrom;
            ValidTill = previousPolicy.ValidTill;
            IList<Risk> selectedRisks = new List<Risk>(previousPolicy.InsuredRisks);
            selectedRisks.Add(addedRisk);
            AdditionalPremium = PolicyCalculations.CalculatePremium(validMonths, new List<Risk> { addedRisk });
            Premium = previousPolicy.Premium + AdditionalPremium;
            InsuredRisks = selectedRisks;
            AdditionalRisk = addedRisk;
            AdditionalValidFrom = additionalValidFrom;
        }
        
        public string NameOfInsuredObject { get; }
    
        public DateTime ValidFrom { get; }
      
        public DateTime ValidTill { get; }
        
        public decimal Premium { get; }
      
        public IList<Risk> InsuredRisks { get; }

        public decimal AdditionalPremium { get;  }

        public Risk AdditionalRisk { get; }

        public DateTime AdditionalValidFrom { get; }
    }
}
