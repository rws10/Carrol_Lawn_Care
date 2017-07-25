namespace Carrol_Lawn_Care.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("TblTool")]
    public partial class Tools
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int toolId { get; set; }

        public int equipId { get; set; }

        public virtual Equip TblEquip { get; set; }
    }
}
