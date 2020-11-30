using NTier.Core.Map;
using NTier.Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NTier.Model.Maps
{
    public class PositionMap : CoreMap<Position>
    {
        public PositionMap()
        {
            ToTable("Positions");
            Property(x => x.Name).IsOptional();
            Property(x => x.Description).IsOptional();
            HasMany(x => x.People).WithRequired(x => x.Position).HasForeignKey(x => x.PositionId);
        }
    }
}
