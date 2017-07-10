using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Carrol_Lawn_Care.Models
{
    public class Person
    {
        /*
         perid CHAR(64) PRIMARY KEY,
	name CHAR(64) NOT NULL,
	phone CHAR(15) NOT NULL,
	address CHAR(128))
         */
        [Key]
        [Required]
        public int perId { get; set;}

        //
        [Required(ErrorMessage = "Title Required")]
        [Display(Name = "Title")]
        public string title { get; set; }
    }
}