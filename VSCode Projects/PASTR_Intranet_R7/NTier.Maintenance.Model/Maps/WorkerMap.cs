using NTier.Core.Map;
using NTier.Maintenance.Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NTier.Maintenance.Model.Maps
{
    public class WorkerMap : CoreMap<Worker>
    {
        public WorkerMap()
        {
            ToTable("Workers") ;
            Property(x => x.Name).IsOptional();
            Property(x => x.LastName).IsOptional();
            HasMany(x => x.Operations).WithRequired(x => x.Worker).HasForeignKey(x => x.WorkerId);
        }
    }
}
