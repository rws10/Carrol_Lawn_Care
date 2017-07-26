using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Carrol_Lawn_Care.Models
{
    [MetadataType(typeof(EquipHelper))]
    public partial class Equip { }

    public class EquipHelper
    {
        public int equipId { get; set; }

        [Display(Name = "Name")]
        public string name { get; set; }

        [Display(Name = "Type of Fuel")]
        public string fuelType { get; set; }

        [Display(Name = "Equipment Type")]
        public string type { get; set; }
    }
}