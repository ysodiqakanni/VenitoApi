namespace VenitoApi
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("EmployeeHistory")]
    public partial class EmployeeHistory
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int id { get; set; }

        [Required]
        public string company { get; set; }

        [Required]
        public string position { get; set; }

        public int yearFrom { get; set; }

        public int? yearTo { get; set; }

        public bool present { get; set; }

        public int employeeId { get; set; }

        public virtual Employee Employee { get; set; }
    }
}
