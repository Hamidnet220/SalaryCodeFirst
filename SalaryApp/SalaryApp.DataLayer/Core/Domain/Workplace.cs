using System.ComponentModel.DataAnnotations.Schema;
using SalaryApp.DataLayer.Migrations;

namespace SalaryApp.DataLayer.Core.Domain
{
    public class Workplace
    {
        public int Id { get; set; }

        [VerboseName("نام موقعیت کاری")]
        public string Title { get; set; }

        public int WorkshopId { get; set; }

        [ForeignKey("WorkshopId")]
        public virtual Workshop Workshop { get; set; }
    }
}