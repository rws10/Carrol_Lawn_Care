namespace Carrol_Lawn_Care.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("TblProp")]
    public partial class Property
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Property()
        {
            TblPers = new HashSet<Person>();
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int propId { get; set; }

        [Required]
        [StringLength(128)]
        public string address { get; set; }

        [Required]
        [StringLength(128)]
        public string services { get; set; }

        public float cost { get; set; }

        [Required]
        [StringLength(15)]
        public string recurrence { get; set; }

        public DateTime? nextCut { get; set; }

        public int? perId { get; set; }

        public int? equipId { get; set; }

        public virtual Equip TblEquip { get; set; }

        public virtual Person TblPer { get; set; }

        public virtual Equip TblEquip1 { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Person> TblPers { get; set; }
    }
}
