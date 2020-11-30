using NTier.Core.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NTier.Maintenance.Model.Entities
{
    public class Notification : CoreEntity
    {
        public string Problem { get; set; }
        public bool NoticeStatus { get; set; }
        public Machine Machine { get; set; }
        
    }
}
