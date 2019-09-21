using System.ComponentModel.DataAnnotations.Schema;

namespace SalaryApp.DataLayer.Core.Domain
{
    public class AppStatus
    {
        public int Id { get; set; }

        public int ActiveUserId { get; set; }
        [ForeignKey("ActiveUserId")]
        public virtual  User User { get; set; }

        public int ActiveWorkShopId { get; set; }
        [ForeignKey("ActiveWorkShopId")]
        public virtual Workshop Workshop { get; set; }


        public int ActiceFinancialYearId { get; set; }
        [ForeignKey("ActiceFinancialYearId")]
        public virtual FinancialYear FinancialYear { get; set; }
    }
}