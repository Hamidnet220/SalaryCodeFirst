using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalaryApp.DataLayer.Core.Domain
{
    public class Workshop
    {
        public int Id { get; set; }

        [Required]
        [StringLength(150)]
        [VerboseName("عنوان کارگاه")]
        public string Title { get; set; }
        [VerboseName("آدرس کارگاه")]
        public string Address { get; set; }
        [VerboseName("تلفن کارگاه")]
        public string Tel { get; set; }
        
    }
}
