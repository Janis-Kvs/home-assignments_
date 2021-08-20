using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IfRisk.Interfaces;

namespace IfRisk
{
    public class Policy : IPolicy
    {
        public Policy(string nameOfInsured, DateTime validFrom, DateTime validTill, decimal premium, IList<Risk> insuredRisks)
        {
            NameOfInsuredObject = nameOfInsured;
            ValidFrom = validFrom;
            ValidTill = validTill;
            Premium = premium;
            InsuredRisks = insuredRisks;
        }
       
        public string NameOfInsuredObject { get; }
       
        public DateTime ValidFrom { get; }
       
        public DateTime ValidTill { get; }
        
        public decimal Premium { get; }
       
        public IList<Risk> InsuredRisks { get; }
    }
}
