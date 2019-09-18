using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalaryApp.DataLayer.Core.Domain
{
    public interface IPayDetails
    {
        decimal GetGrossAmount();
        decimal GetTaxAmount();
        decimal GetInsuranceAmount();
        decimal GetNetAmount();
        
    }
}
