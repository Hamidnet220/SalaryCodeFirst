using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalaryApp.DataLayer.Core.Domain
{
    public class Pay
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public Workshop Workshop { get; set; }
        public FincancialYear FinancialYear { get; set; }
        public int EmployeesCount { get; set; }
        public decimal TotalGrossAmount { get; set; }
        public decimal TotalTaxAmount { get; set; }
        public decimal TotalInsuraceAmount { get; set; }
        public decimal TotalNetAmount { get; set; }
    }
}
