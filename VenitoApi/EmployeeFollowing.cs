namespace VenitoApi
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("EmployeeFollowing")]
    public partial class EmployeeFollowing
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int id { get; set; }

        public int jobId { get; set; }

        public int employeeId { get; set; }

        public virtual Employee Employee { get; set; }

        public virtual Job Job { get; set; }
    }
}
