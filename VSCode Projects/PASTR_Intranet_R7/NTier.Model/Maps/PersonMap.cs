using NTier.Core.Map;
using NTier.Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NTier.Model.Maps
{
    public class PersonMap : CoreMap<Person>
    {
        public PersonMap()
        {
            ToTable("People");
            Property(x => x.Name).IsRequired();
            Property(x => x.LastName).IsRequired();
            Property(x => x.TCKN).IsOptional().HasMaxLength(11).IsFixedLength();
            Property(x => x.Gender).IsOptional();
            Property(x => x.BirthDate).IsRequired().HasColumnType("datetime2");
            HasMany(x => x.Directories).WithRequired(x => x.Person).HasForeignKey(x => x.PersonId);
        }
    }
}
