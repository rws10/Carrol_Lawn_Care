namespace Carrol_Lawn_Care.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("TblEmp")]
    public partial class Employees
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int empId { get; set; }

        public int perId { get; set; }

        public float payRate { get; set; }

        public int ssn { get; set; }

        public int managedBy { get; set; }

        public virtual Person TblPer { get; set; }

        public virtual Person TblPer1 { get; set; }
    }
}
