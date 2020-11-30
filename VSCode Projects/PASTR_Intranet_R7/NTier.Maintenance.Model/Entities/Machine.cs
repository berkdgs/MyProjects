using NTier.Core.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NTier.Maintenance.Model.Entities
{
    public class Machine : CoreEntity
    {
        public String Name { get; set; }
        public String Description { get; set; }
        public List<Operation> Operations { get; set; }
        public List<Notification> Notifications { get; set; }

    }
}
