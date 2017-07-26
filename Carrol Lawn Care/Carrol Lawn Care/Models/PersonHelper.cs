using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Carrol_Lawn_Care.Models
{
    [MetadataType(typeof(PersonHelper))]
    public partial class Person { }

    public class PersonHelper
    {
        [Display(Name = "Name")]
        public string name { get; set; }

        [Display(Name = "Phone Number")]
        public string phone { get; set; }

        [Display(Name = "Address")]
        public string address { get; set; }
    }
}