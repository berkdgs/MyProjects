using NTier.Core.Map;
using NTier.Maintenance.Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NTier.Maintenance.Model.Maps
{
    public class OperationMap :CoreMap<Operation>
    {
        public OperationMap()
        {
            ToTable("Operations");
            //Property(x => x.Problem).IsOptional();
            Property(x => x.Process).IsOptional();
            Property(x => x.ProcessStatu).IsOptional();
            
        }
    }
}
