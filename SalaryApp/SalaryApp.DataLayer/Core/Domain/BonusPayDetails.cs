using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalaryApp.DataLayer.Core.Domain
{
    public class BonusPayDetails:IPayDetails
    {
        public int Id { get; set; }
        public int PayId { get; set; }
        [ForeignKey("PayId")]
        public Pay Pay { get; set; }
        public int EmployeeId { get; set; }
        [ForeignKey("EmployeeId")]
        public Employee Employee { get; set; }
        public decimal DailyRate { get; set; }
        public decimal GrossAmount { get; set; }
        public int DaysOfWork { get; set; }
        public bool IsTaxExempt { get; set; }
        public decimal TaxIncluded { get; set; }
        public decimal TaxAmount { get; set; }
        public decimal PayInAdvance { get; set; }
        public decimal Loan { get; set; }
        public decimal InPartPayment { get; set; }
        public decimal OtherDeduction { get; set; }
        public decimal OtherDeduction1 { get; set; }
        public decimal NetAmount { get; set; }
        public string Description { get; set; }
    }
}
