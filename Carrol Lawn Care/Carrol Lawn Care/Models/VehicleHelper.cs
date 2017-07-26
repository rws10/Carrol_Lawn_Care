using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Carrol_Lawn_Care.Models
{
    [MetadataType(typeof(VehicleHelper))]
    public partial class Vehicle { }

    public class VehicleHelper
    {
        [Display(Name = "License Plate")]
        public string licPlate { get; set; }

        [Display(Name = "Assigned Truck")]
        public virtual Equip TblEquip { get; set; }
    }
}