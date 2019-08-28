using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace SalaryApp.DataLayer.Core.Domain
{
    public class Employee
    {
        public int Id { get; set; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public string FatherName { get; set; }
        public string IdNumber { get; set; }
        public string NationalCode { get; set; }
        public int Age { get; set; }
        public bool IsMarrid { get; set; }
        public byte NumberOfChildren { get; set; }
        public string Address { get; set; }
        public string Mobile { get; set; }
        public DateTime? DOB { get; set; }
        public int POB { get; set; }
        public int POI { get; set; }

    }
}
