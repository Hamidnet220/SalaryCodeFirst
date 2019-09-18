using System.ComponentModel.DataAnnotations.Schema;

namespace SalaryApp.DataLayer.Core.Domain
{
    public class Logsheet
    {
        public int Id { get; set; }

        public int PayId { get; set; }
        
        public virtual Pay Pay { get; set; }

        public int EmployeeId { get; set; }

        [VerboseName("نام کارمند")]
        [ForeignKey("EmployeeId")]
        public virtual Employee Employee { get; set; }

        public string DayStatus { get; set; }
    }
}
