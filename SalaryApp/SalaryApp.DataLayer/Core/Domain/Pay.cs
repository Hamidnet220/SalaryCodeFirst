using System.ComponentModel.DataAnnotations.Schema;

namespace SalaryApp.DataLayer.Core.Domain
{
    public class Pay
    {
        public int Id { get; set; }

        [VerboseName("عنوان پرداخت:")]
        public string Title { get; set; }

        public int PayType_Id { get; set; }
        [ForeignKey("PayType_Id")]
        public virtual PayType PayType { get; set; }

        public int Workshop_Id { get; set; }
        [ForeignKey("Workshop_Id")]
        public virtual Workshop Workshop { get; set; }

        public int FinancialYear_Id { get; set; }
        [VerboseName("شناسه ماه:")]
        public int MonthId { get; set; }
        [VerboseName("تعداد کارکنان:")]
        public int EmployeesCount { get; set; }
        public decimal TotalGrossAmount { get; set; }
        public decimal TotalTaxAmount { get; set; }
        public decimal TotalInsuraceAmount { get; set; }
        public decimal TotalNetAmount { get; set; }
        public byte Status { get; set; }
        public bool IsDeleted { get; set; }

    }

    
}
