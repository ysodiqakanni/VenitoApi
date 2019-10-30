namespace VenitoApi
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class OpenPosition
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int id { get; set; }

        public int employerId { get; set; }

        public int jobId { get; set; }

        [Required]
        public string description { get; set; }

        public int salaryRangeFrom { get; set; }

        public int salaryRangeTo { get; set; }

        public virtual Employer Employer { get; set; }

        public virtual Job Job { get; set; }
    }
}
