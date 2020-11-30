using NTier.Core.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NTier.Model.Entities
{
    public class Department : CoreEntity
    {
        public String Name { get; set; }
        public String Description { get; set; }
        public virtual List<Person> People { get; set; }
    }
}
