﻿using System.ComponentModel.DataAnnotations.Schema;

namespace SalaryApp.DataLayer.Core.Domain
{
    public class Workgroup
    {
        public int Id { get; set; }

        [VerboseName("عنوان گروه")]
        public string Title { get; set; }

        [VerboseName("پايه روزانه")]
        public decimal Rate { get; set; }

        [VerboseName("بن")]
        public decimal Bon { get; set; }

        [VerboseName("مسکن")]
        public decimal Maskan { get; set; }

        [VerboseName("مبلغ جايگزيني")]
        public decimal StandbayAmount { get; set; }

        [VerboseName("مبلغ حق اولاد")]
        public decimal ChildrenBenefit { get; set; }

        [VerboseName("مبلغ حق غذا")]
        public decimal FoodBenefitAmount { get; set; }

        [VerboseName("وضعيت شيفت")]
        public bool IsShift { get; set; }

        [VerboseName("درصد حق شيفت")]
        public float ShiftRation { get; set; }

        [VerboseName("مبلغ معافیت مالياتی")]
        public decimal TaxExeptAmount { get; set; }

        [VerboseName("(درصد مالیات(ماده 84")]
        public float TaxRatio { get; set; }

        [VerboseName("سرانه بهداشت")]
        public decimal HygieneAmount { get; set; }

        [VerboseName("توضيحات")]
        public string Description { get; set; }

        public int Workshop_Id { get; set; }

        [ForeignKey("Workshop_Id")]
        public virtual Workshop Workshop { get; set; }
    }
}                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                               