using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IfScooters
{
    interface IRentalCompany
    {
        string Name { get; }

        void StartRent(string id, DateTime pickTime);

        decimal EndRent(string id, DateTime returnTime);

        decimal CalculateIncome(int? year, bool includeNotCompletedRentals, DateTime returnTime);
    }
}
