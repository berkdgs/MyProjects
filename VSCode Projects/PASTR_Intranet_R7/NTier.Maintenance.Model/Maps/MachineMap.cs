using NTier.Core.Map;
using NTier.Maintenance.Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NTier.Maintenance.Model.Maps
{
    public class MachineMap : CoreMap<Machine>
    {
        public MachineMap()
        {
            ToTable("Machines");
            Property(x => x.Name).IsRequired().IsFixedLength().HasMaxLength(8);
            Property(x => x.Description).IsOptional();
            HasMany(x => x.Operations).WithRequired(x => x.Machine).HasForeignKey(x => x.MachineId);
            HasMany(x => x.Notifications);
        }
    }
}
