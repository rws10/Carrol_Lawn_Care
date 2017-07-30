using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Carrol_Lawn_Care.Models
{
    [MetadataType(typeof(PropHelper))]
    public partial class Prop { }

    public class PropHelper
    {
        [Display(Name = "Address")]
        public string address { get; set; }

        [Display(Name = "Services")]
        public string services { get; set; }

        [Display(Name = "Cost")]
        public float cost { get; set; }

        [Display(Name = "Recurrence")]
        public string recurrence { get; set; }

        [Display(Name = "Next Cut")]
        public Nullable<System.DateTime> nextCut { get; set; }

        [Display(Name = "Assigned Truck")]
        public virtual Equip TblEquip { get; set; }

        [Display(Name = "Owners")]
        public virtual ICollection<Person> TblOwns { get; set; }
    }
}