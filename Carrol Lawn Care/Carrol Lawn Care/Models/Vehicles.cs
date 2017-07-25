namespace Carrol_Lawn_Care.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("TblVehicle")]
    public partial class Vehicles
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int vehId { get; set; }

        public int equpId { get; set; }

        [Required]
        [StringLength(12)]
        public string licPlate { get; set; }

        public virtual Equip TblEquip { get; set; }
    }
}
