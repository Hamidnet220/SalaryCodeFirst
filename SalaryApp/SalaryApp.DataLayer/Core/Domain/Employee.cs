namespace SalaryApp.DataLayer.Core.Domain
{
    public class Employee
    {
        public int Id { get; set; }
        public virtual Person Person { get; set; }
        public virtual Workshop Workshop { get; set; }
        public virtual Workgroup Workgroup { get; set; }
        public virtual Workplace Workplace { get; set; }
    }
}
