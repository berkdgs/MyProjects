using NTier.Core.Entity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NTier.Core.Map
{
    public class CoreMap<T> : EntityTypeConfiguration<T> where T: CoreEntity
    {
        public CoreMap()
        {
            Property(x => x.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            Property(x => x.CreatedDate).IsOptional();
            Property(x => x.CreatedComputerName).IsOptional();
            Property(x => x.CreatedUserName).IsOptional();
            Property(x => x.ModifiedDate).IsOptional();
            Property(x => x.ModifiedComputerName).IsOptional();
            Property(x => x.ModifiedUserName).IsOptional();
            Property(x => x.Status).IsOptional();
        }
    }
}
