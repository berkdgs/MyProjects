using NTier.Core.Map;
using NTier.Maintenance.Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NTier.Maintenance.Model.Maps
{
    public class NotificationMap : CoreMap<Notification>
    {
        public NotificationMap()
        {
            ToTable("Notifications");
            Property(x => x.Problem).IsRequired();
            
        }
    }
}
