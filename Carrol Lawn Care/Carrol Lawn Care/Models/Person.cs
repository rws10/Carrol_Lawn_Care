using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Carrol_Lawn_Care.Models
{
    public class Person
    {
        
        [Key]
        [Required]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int perId { get; set;}

        [Required(ErrorMessage = "Name Required")]
        [Display(Name = "Name")]
        public string name { get; set; }

        [Display(Name = "Name")]
        public string phone { get; set; }

        [Display(Name = "Address")]
        public string address { get; set; }
    }
}