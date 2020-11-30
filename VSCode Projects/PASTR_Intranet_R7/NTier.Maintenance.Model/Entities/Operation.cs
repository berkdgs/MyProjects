using NTier.Core.Entity;
using NTier.Maintenance.Model.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NTier.Maintenance.Model.Entities
{
    public class Operation : CoreEntity
    {
        public Guid MachineId { get; set; }
        //public String Problem { get; set; }
        public String Process { get; set; }
        public Guid WorkerId { get; set; }
        public Guid NotificationId { get; set; }
        public ProcessStatu ProcessStatu{ get; set; }
        public Machine Machine { get; set; }
        public Worker Worker { get; set; }
        public Notification Notification { get; set; }
    }
}
