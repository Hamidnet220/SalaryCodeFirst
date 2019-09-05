using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalaryApp.DataLayer.Core.Domain
{
    public class Education
    {
        public int Id { get; set; }
        [VerboseName("عنوان")]
        public string Title { get; set; }
        [VerboseName("توضیحات")]
        public string Desc { get; set; }

    }
}
