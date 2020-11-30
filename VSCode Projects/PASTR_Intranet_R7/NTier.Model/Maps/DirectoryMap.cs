using NTier.Core.Map;
using NTier.Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NTier.Model.Maps
{
    public class DirectoryMap : CoreMap<Directory>
    {
        public DirectoryMap()
        {
            ToTable("Directories");
            Property(x => x.PhoneNumber).IsOptional();
            Property(x => x.PhoneType).IsOptional();
        }
    }
}
