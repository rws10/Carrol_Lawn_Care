using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Carrol_Lawn_Care.Models
{
    [MetadataType(typeof(MaintenanceRecordHelper))]
    public partial class MaintenanceRecord { }

    public class MaintenanceRecordHelper
    {
        [Display(Name = "Type of Maintenance")]
        public string maintType { get; set; }

        [Display(Name = "Cost")]
        public float cost { get; set; }

        [Display(Name = "Date of Maintenance")]
        public System.DateTime date { get; set; }

        [Display(Name = "Assigned Equipment")]
        public virtual Equip TblEquip { get; set; }
    }
}