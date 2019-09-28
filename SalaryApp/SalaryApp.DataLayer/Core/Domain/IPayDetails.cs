using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace SalaryApp.DataLayer.Core.Domain
{
    public interface IPayDetails
    {
         int Id { get; set; }
         int PayId { get; set; }
         Pay Pay { get; set; }
         int EmployeeId { get; set; }
         Employee Employee { get; set; }
         decimal DailyRate { get; set; }
         int DaysOfWork { get; set; }
         decimal GrossAmount { get; set; }
         bool IsTaxExempt { get; set; }
         decimal TaxIncluded { get; set; }
         decimal TaxAmount { get; set; }
         decimal PayInAdvance { get; set; }
         decimal Loan { get; set; }
         decimal InPartPayment { get; set; }
         decimal OtherDeduction { get; set; }
         decimal OtherDeduction1 { get; set; }
         decimal NetAmount { get; set; }
    }
}