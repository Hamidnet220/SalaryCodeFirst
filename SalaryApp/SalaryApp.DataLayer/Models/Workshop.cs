using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalaryApp.DataLayer.Models
{
    public class Workshop
    {
        public int Id { get; set; }

        [Required]
        [StringLength(150)]
        public string Title { get; set; } 

        public string Address { get; set; }
        public string Tel { get; set; }
        
    }
}
