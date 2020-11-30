using NTier.Core.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NTier.Core.Entity
{
    public class CoreEntity
    {
        public Guid Id { get; set; }
        public DateTime? CreatedDate { get; set; }
        public String CreatedComputerName { get; set; }
        public String CreatedUserName { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public String ModifiedComputerName { get; set; }
        public String ModifiedUserName { get; set; }
        public Status Status { get; set; }
    }
}
