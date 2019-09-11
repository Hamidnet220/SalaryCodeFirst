using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalaryApp.DataLayer.Core.Domain
{
    public class Workgroup
    {
        public int Id { get; set; }

        [VerboseName("عنوان گروه")]
        public string Title { get; set; }

        [VerboseName("پایه روزانه")]
        public decimal Rate { get; set; }

        [VerboseName("بن")]
        public decimal Bon { get; set; }

        [VerboseName("مسکن")]
        public decimal Maskan { get; set; }

        [VerboseName("مبلغ حق اولاد")]
        public decimal ChildrenBenefit { get; set; }

        [VerboseName("وضعیت شیفت")]
        public bool? IsShift { get; set; }

        [VerboseName("درصد حق شیفت")]
        public float ShiftRation { get; set; }

        [VerboseName("معاف از مالیات")]
        public decimal TaxExept { get; set; }

        [VerboseName("توضیحات")]
        public string Description { get; set; }
        public int Workshop_Id { get; set; }

        [ForeignKey("Workshop_Id")]
        public virtual Workshop Workshop { get; set; }
    }
}
