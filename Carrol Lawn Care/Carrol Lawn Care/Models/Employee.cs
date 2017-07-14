using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Carrol_Lawn_Care.Models
{
    public class Employee
    {
        [Key]
        [Required]
        public int empid { get; set;}

        // the parent object (person) of this employee
        [ForeignKey("Person")]
        [Required]
        public int perid { get; set;}

        public virtual Person person { get; set;}

        // how much the employee is paid
        [Required(ErrorMessage = "Name Required")]
        public double payRate { get; set;}

        // the employee's social security number
        public int ssn { get; set;}

        // if the employee is not a manager, who is their manager?
        public int managedby { get; set; }

        // if the employee is a manager, who do they manage?
        public int manages { get; set; }

    }
}