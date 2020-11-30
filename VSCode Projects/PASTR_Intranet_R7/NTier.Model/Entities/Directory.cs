using NTier.Core.Entity;
using NTier.Model.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NTier.Model.Entities
{
    public class Directory : CoreEntity
    {
        public PhoneType PhoneType { get; set; }
        public String PhoneNumber { get; set; }
        public Guid PersonId { get; set; }
        public virtual Person Person { get; set; }

    }
}
