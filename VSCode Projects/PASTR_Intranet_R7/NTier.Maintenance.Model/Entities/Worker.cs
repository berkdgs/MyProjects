using NTier.Core.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NTier.Maintenance.Model.Entities
{
    public class Worker : CoreEntity
    {
        public String Name { get; set; }
        public String LastName { get; set; }
        public String Perfection { get; set; }
        public List<Operation> Operations { get; set; }
        public String LongName {get => Name + " " + LastName;}
        
    }
}
