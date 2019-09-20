using System;

namespace SalaryApp.DataLayer.Core
{
    [AttributeUsage(AttributeTargets.Property)]
    public class ComboBoxAttribute : Attribute
    {
        public ComboBoxAttribute(string sourceName)
        {
            SourceName = sourceName;
        }

        public string SourceName { get; set; }
    }
}