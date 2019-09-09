using System;

namespace SalaryApp.DataLayer.Core.Domain
{
    public class Employee
    {
        public int Id { get; set; }
        [VerboseName("نام:")]
        public string Firstname { get; set; }
        [VerboseName("نام خانوادگی:")]
        public string Lastname { get; set; }
        [VerboseName("نام پدر:")]
        public string FatherName { get; set; }
        [VerboseName("شماره شناسنامه:")]
        public string IdNumber { get; set; }
        [VerboseName("کد ملی:")]
        public string NationalCode { get; set; }
        [VerboseName("شماره بیمه:")]
        public string InsuranceId { get; set; }
        [VerboseName("سن:")]
        public int Age { get; set; }
        [VerboseName("وضعیت تاهل:")]
        public bool IsMarrid { get; set; }
        [VerboseName("تعداد فرزند:")]
        public byte NumberOfChildren { get; set; }
        [VerboseName("آدرس:")]
        public string Address { get; set; }
        [VerboseName("شماره همراه:")]
        public string Mobile { get; set; }
        [VerboseName("تاریخ تولد:")]
        public DateTime? DOB { get; set; }

        [VerboseName("محل تولد:")]
        [ComboBox("City")]
        public int POB { get; set; }

        [VerboseName("محل صدور:")]
        public int POI { get; set; }
        [VerboseName("شماره حساب بانکی:")]
        public string BankAccount { get; set; }
        [VerboseName("میزان تحصیلات:")]
        public Education Education { get; set; }


    }
}
