using System;

namespace SalaryApp.DataLayer.Core
{
    [AttributeUsage(AttributeTargets.Property)]
    public class VerboseNameAttribute : Attribute
    {
        public VerboseNameAttribute(string VerboseName)
        {
            this.VerboseName = VerboseName;
        }

        public string VerboseName { get; set; }
    }
}