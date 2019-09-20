using System.ComponentModel.DataAnnotations.Schema;

namespace SalaryApp.DataLayer.Core.Domain
{
    public class Employee
    {
        public int Id { get; set; }

        public int Person_Id { get; set; }

        [ForeignKey("Person_Id")]
        public virtual Person Person { get; set; }

        //public int Workshop_Id { get; set; }
        //[ForeignKey("Workshop_Id")]
        //public virtual Workshop Workshop { get; set; }

        public int Workgroup_Id { get; set; }

        [ForeignKey("Workgroup_Id")]
        public virtual Workgroup Workgroup { get; set; }

        public int Workplace_Id { get; set; }

        [ForeignKey("Workplace_Id")]
        public virtual Workplace Workplace { get; set; }
    }
}