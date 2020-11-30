using NTier.Core.Enums;
using NTier.Model.Context;
using NTier.Model.Entities;
using NTier.Service.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NTier.Service.Option
{
    public class PersonService : BaseService<Person>
    {
        public List<Person> GetBirthDays()
        {
            return GetActive().Where(x => x.BirthDay == true).ToList();
        }
    }
}
