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
    
    public partial class View_all_stops
    {
        public int DocumentID { get; set; }
        public decimal Code { get; set; }
        public short Events { get; set; }
        public System.DateTime ProductionDate { get; set; }
        public string Team { get; set; }
        public int Shift { get; set; }
        public string Machine { get; set; }
        public string Department { get; set; }
        public Nullable<int> Time { get; set; }
        public short addCapacity { get; set; }
        public Nullable<short> ThTime { get; set; }
    }
}
