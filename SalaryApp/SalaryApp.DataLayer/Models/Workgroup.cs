using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalaryApp.DataLayer.Models
{
    public class Workgroup
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public decimal Rate { get; set; }
        public decimal Bon { get; set; }
        public decimal Maskan { get; set; }
        public decimal ChildrenBenefit { get; set; }
        public bool? IsShift { get; set; }
        public float ShiftRation { get; set; }
        public decimal TaxExept { get; set; }
        public string Description { get; set; }
        public Workshop Workshop { get; set; }
    }
}
