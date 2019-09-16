using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;
namespace SalaryApp.DataLayer.Core.Domain
{
    public class Logsheet
    {
        int[] days = new int[30];

        public int Id { get; set; }

        public int Pay_Id { get; set; }
        
        public virtual Pay Pay { get; set; }

        public int Day_1 { get; set; }

        public int Day_2 { get; set; }

        public int Day_3 { get; set; }

        public int Day_4 { get; set; }

        public int Day_5 { get; set; }

        public int Day_6 { get; set; }

        public int Day_7 { get; set; }

        public int Day_8 { get; set; }
  
        public int Day_9 { get; set; }

        public int Day_10 { get; set; }

        public int Day_11 { get; set; }

        public int Day_12 { get; set; }

        public int Day_13 { get; set; }

        public int Day_14 { get; set; }

        public int Day_15 { get; set; }

        public int Day_16 { get; set; }

        public int Day_17 { get; set; }

        public int Day_18 { get; set; }

        public int Day_19 { get; set; }

        public int Day_20 { get; set; }

        public int Day_21 { get; set; }

        public int Day_22 { get; set; }

        public int Day_23 { get; set; }

        public int Day_24 { get; set; }

        public int Day_25 { get; set; }

        public int Day_26 { get; set; }

        public int Day_27 { get; set; }

        public int Day_28 { get; set; }

        public int Day_29 { get; set; }

        public int Day_30 { get; set; }

        public int Day_31 { get; set; }


    }
}
