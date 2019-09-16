using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalaryApp.DataLayer.Core.Domain
{
    public class WorkDayStatus
    {
        public int Id { get; set; }

        public int Code { get; set; }

        public string Ttile { get; set; }

        public string ShortName { get; set; }

        public bool IsWorkDay { get; set; }
    }
}
