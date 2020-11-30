using NTier.Maintenance.Model.Entities;
using NTier.Maintenance.Model.Enums;
using NTier.Maintenance.Service.Base;
using System;
using System.Collections.Generic;

namespace NTier.Maintenance.Service.Optional
{
    public class OperationService : BaseService<Operation>
    {
        public List<Operation> GetByMachine(Guid id)
        {
            return GetDefault(x => x.MachineId == id);
        }
        public List<Operation> GetByPerson(Guid id)
        {
            List<Operation> operations = GetDefault(x => x.WorkerId == id);
            return GetDefault(x => x.WorkerId == id);
        }
        public Boolean AnyOpenOperation(Guid id)
        {
            return Any(x => x.MachineId == id && x.ProcessStatu != ProcessStatu.Tamamlandi);
        }
        public Operation OpenOperation(Guid id)
        {
            return GetByDefault(x => x.MachineId == id && x.ProcessStatu != ProcessStatu.Tamamlandi);
        }
    }
}
