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
    
    public partial class Own
    {
        public int ownId { get; set; }
        public int perId { get; set; }
        public int propId { get; set; }
    
        public virtual Person TblPer { get; set; }
        public virtual Prop TblProp { get; set; }
    }
}
