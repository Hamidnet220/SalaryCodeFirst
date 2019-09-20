using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SalaryApp.DataLayer.Core.Domain
{
    public class FinancialYear
    {
        public int Id { get; set; }

        [Required]
        [Index(IsUnique = true)]
        public int Year { get; set; }

        public int Workshop_Id { get; set; }
        public bool? IsDeleted { get; set; }
    }
}