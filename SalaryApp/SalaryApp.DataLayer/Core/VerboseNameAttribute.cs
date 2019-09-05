using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalaryApp.DataLayer.Core
{
    [AttributeUsage(AttributeTargets.Property,AllowMultiple =false,Inherited =false)]
    public class VerboseNameAttribute:Attribute
    {
        public VerboseNameAttribute(string VerboseName)
        {
            this.VerboseName = VerboseName;
        }
        public string VerboseName { get; set; }
    }
}
