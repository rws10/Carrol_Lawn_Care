using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Carrol_Lawn_Care.Models
{
    [MetadataType(typeof(CustomerHelper))]
    public partial class Customer { }

    public class CustomerHelper
    {
        [Display(Name = "Co-Owner")]
        public virtual Person TblPer { get; set; }
    }
}