//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace PASTR.Intranet.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class CardSteps
    {
        public int ID { get; set; }
        public int DocumentID { get; set; }
        public decimal Code { get; set; }
        public short Fields { get; set; }
        public short Events { get; set; }
        public bool Active { get; set; }
        public Nullable<int> ProductionID { get; set; }
        public short addCapacity { get; set; }
    
        public virtual MachineSteps MachineSteps { get; set; }
    }
}