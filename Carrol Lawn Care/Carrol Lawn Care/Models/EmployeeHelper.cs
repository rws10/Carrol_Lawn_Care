using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Carrol_Lawn_Care.Models
{
    [MetadataType(typeof(EmployeeHelper))]
    public partial class Employee { }

    public class EmployeeHelper
    {
        [Display(Name = "Rate of Pay")]
        public float payRate { get; set; }

        [Display(Name = "SSN")]
        public string ssn { get; set; }
    }
}