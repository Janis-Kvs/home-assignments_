using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IfScooters
{
    public interface IRentalAccounting
    {
        decimal CalculatePrice(RentedScooters rentedScooter);

        decimal GetIncome(int? year);

        decimal GetIncomeFromInRentScooters(List<RentedScooters> rentedScooters, DateTime incomeTime);
    }
}
