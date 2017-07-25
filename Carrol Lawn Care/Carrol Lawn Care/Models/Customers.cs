namespace Carrol_Lawn_Care.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("TblCust")]
    public partial class Customers
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int custId { get; set; }

        public int perId { get; set; }

        public virtual Person TblPer { get; set; }
    }
}
