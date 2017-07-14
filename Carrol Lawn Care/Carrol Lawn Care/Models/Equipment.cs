using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Carrol_Lawn_Care.Models
{
    public class Equipment
    {
        [Key]
        [Required]
        public int equipid { get; set; }

        [Display(Name = "Name")]
        string name { get; set; }

        [Required(ErrorMessage = "Fuel type required")]
        [Display(Name = "Type of Fuel")]
        string fuelType { get; set; }

        [Required(ErrorMessage = "Equipment type required")]
        [Display(Name = "Type of Equipment")]
        string equipmentType { get; set; }

        //maintrecord CHAR(64))

    }
}