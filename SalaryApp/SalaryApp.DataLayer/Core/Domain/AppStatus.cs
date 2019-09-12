using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalaryApp.DataLayer.Core.Domain
{
    public static class AppStatus
    {
        public static int Id{ get; set; }
        public static int ActiveUserId { get; set; }
        public static int ActiveWorkShopId { get; set; }
        public static int ActiceFinancialYearId { get; set; }
    }
}
