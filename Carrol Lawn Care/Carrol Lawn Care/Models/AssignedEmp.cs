//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Carrol_Lawn_Care.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class AssignedEmp
    {
        public int assignId { get; set; }
        public int empId { get; set; }
        public int truckId { get; set; }
    
        public virtual Person TblPer { get; set; }
        public virtual Equip TblEquip { get; set; }
    }
}
