namespace Carrol_Lawn_Care.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("TblMaintRec")]
    public partial class MaintenanceRecords
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int maintId { get; set; }

        public int equipId { get; set; }

        [Required]
        [StringLength(30)]
        public string maintType { get; set; }

        public float cost { get; set; }

        public DateTime date { get; set; }

        public virtual Equip TblEquip { get; set; }
    }
}
