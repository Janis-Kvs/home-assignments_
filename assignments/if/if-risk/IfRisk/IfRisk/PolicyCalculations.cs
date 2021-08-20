using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IfRisk.Exceptions;

namespace IfRisk
{
    public static class PolicyCalculations
    {
        public static decimal CalculatePremium(short validMonths, IList<Risk> selectedRisks)
        {
            decimal premium = 0;
            foreach (var risk in selectedRisks)
            {
                premium += risk.YearlyPrice / 12 * validMonths;
            }
            return Math.Round(premium,2);
        }

        public static short CalculateValidMonths(DateTime validFrom, DateTime validTill)
        {
            if (validFrom > validTill)
            {
                throw new InvalidTimePeriodException("The policy start date cannot be after policy end date!")
            }
                long validFromTicks = validFrom.Ticks;
            long validTillTicks = validTill.Ticks;
            TimeSpan span = TimeSpan.FromTicks(validTillTicks - validFromTicks);
            short validMonths = (short)Math.Round((span.TotalDays / 30), 2);

            return validMonths;
        }
    }
}
