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
    
    public partial class BasicMaterial
    {
        public int MaterialID { get; set; }
        public string Plant { get; set; }
        public string Material { get; set; }
        public string Machine { get; set; }
        public string Description { get; set; }
        public decimal Time { get; set; }
        public string Unit { get; set; }
        public decimal BaseQuantity { get; set; }
        public bool Active { get; set; }
        public System.DateTime DateFrom { get; set; }
        public System.DateTime DateTo { get; set; }
        public bool Change { get; set; }
    }
}