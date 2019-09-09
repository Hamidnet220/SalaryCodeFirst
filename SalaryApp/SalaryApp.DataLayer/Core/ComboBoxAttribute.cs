using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalaryApp.DataLayer.Core
{
    [AttributeUsage(AttributeTargets.Property,AllowMultiple =false,Inherited =false)]
    public class ComboBoxAttribute:Attribute
    {
        public string SourceName { get; set; }

        public ComboBoxAttribute(string sourceName)
        {
            this.SourceName = sourceName;
        }
    }
}
