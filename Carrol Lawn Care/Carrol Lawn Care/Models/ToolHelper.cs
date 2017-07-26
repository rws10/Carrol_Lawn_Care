using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Carrol_Lawn_Care.Models
{
    [MetadataType(typeof(ToolHelper))]
    public partial class Tool { }

    public class ToolHelper
    {
        [Display(Name = "Assigned Truck")]
        public virtual Equip TblEquip { get; set; }
    }
}