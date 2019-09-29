using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalaryApp.DataLayer.Core
{
    [AttributeUsage(AttributeTargets.Property,AllowMultiple = false,Inherited = false)]
    public class YesNoComboBoxAttribute:Attribute
    {
        public string Title { get; set; }

        public YesNoComboBoxAttribute(string title)
        {
            Title = title;
        }
    }
}
