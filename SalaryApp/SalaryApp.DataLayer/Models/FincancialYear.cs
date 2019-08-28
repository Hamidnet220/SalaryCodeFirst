using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalaryApp.DataLayer.Models
{
    public class FincancialYear
    {
       public int Id { get; set; }
       
       [Required] 
       [Index(IsUnique=true)]
       public int Year { get; set; }
       public Workshop Workshop { get; set; }
       public bool? IsDeleted { get; set; }
    }
}
