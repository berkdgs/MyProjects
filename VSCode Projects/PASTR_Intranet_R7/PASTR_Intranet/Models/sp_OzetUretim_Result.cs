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
    
    public partial class sp_OzetUretim_Result
    {
        public string Department { get; set; }
        public System.DateTime ProductionDate { get; set; }
        public Nullable<decimal> tpUretim { get; set; }
        public Nullable<int> tpHatali { get; set; }
        public Nullable<int> tpSure { get; set; }
        public Nullable<decimal> OrtalamaUretimSuresi { get; set; }
        public Nullable<int> tpDurus { get; set; }
    }
}