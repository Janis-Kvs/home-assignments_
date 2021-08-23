using IfRisk.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IfRisk.Exceptions;
using System.Xml.Linq;

namespace IfRisk
{
    public class InsuranceCompany : IInsuranceCompany
    {
        public string Name { get; }
        public IList<Risk> AvailableRisks { get; set; }
        private List<IPolicy> _policies;

        public InsuranceCompany(string name, IList<Risk> risks)
        {
            Name = name;
            AvailableRisks = risks;
            _policies = new List<IPolicy>();
        }
        
        public IPolicy SellPolicy(string nameOfInsuredObject, DateTime validFrom, short validMonths, IList<Risk> selectedRisks)
        {
            DateTime validTill = validFrom.AddMonths(validMonths);
            decimal premium = PolicyCalculations.CalculatePremium(validMonths, selectedRisks);
            IPolicy policy = new Policy(nameOfInsuredObject, validFrom, validTill, premium, selectedRisks);
            _policies.Add(policy);
            return policy;
        }
        
        public void AddRisk(string nameOfInsuredObject, Risk risk, DateTime validFrom) // add exception when past date is as argument or out of insurance date
        {
            long validFromTicks = validFrom.Ticks;
            var name = _policies.Find(x => x.NameOfInsuredObject == nameOfInsuredObject);
            var policies = _policies.FindAll(x => x.NameOfInsuredObject == nameOfInsuredObject
                                                  && x.ValidFrom.Ticks <= validFromTicks
                                                  && x.ValidTill.Ticks >= validFromTicks);
            if (name is null)
            {
                throw new PolicyDoesNotExistException("There is no policies with the name of insured object!");
            }
            
            if (policies.Count == 0)
            {
                throw new PolicyDoesNotExistException("There is no policies within the requested period of time!");
            }

            var actualPolicy = policies[0];
            foreach (var policy in policies)
            {
                if (policy.InsuredRisks.Count > actualPolicy.InsuredRisks.Count)
                {
                    actualPolicy = policy;
                }
            }

            var validMonths = PolicyCalculations.CalculateValidMonths(validFrom, actualPolicy.ValidTill);
            IPolicy updatedpolicy = new UpdatedPolicy(actualPolicy, validMonths, risk, validFrom);
            _policies.Add(updatedpolicy);
        }
   
        public IPolicy GetPolicy(string nameOfInsuredObject, DateTime effectiveDate)
        {
            var name = _policies.Find(x => x.NameOfInsuredObject == nameOfInsuredObject);
            var policies = _policies.FindAll(x => x.NameOfInsuredObject == nameOfInsuredObject
                                             && x.ValidFrom == effectiveDate);

            if (name is null)
            {
                throw new PolicyDoesNotExistException("There is no policies with the name of insured object!");
            }
            
            if (policies.Count == 0)
            {
                throw new PolicyDoesNotExistException("There is no policies within the requested period of time!");
            }

            var actualPolicy = policies[0];
            foreach (var policy in policies)
            {
                if (policy.InsuredRisks.Count > actualPolicy.InsuredRisks.Count)
                {
                    actualPolicy = policy;
                }
            }
            return actualPolicy;
        }
    }
}
