namespace VenitoApi
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Employer")]
    public partial class Employer
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Employer()
        {
            OpenPositions = new HashSet<OpenPosition>();
        }

        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int id { get; set; }

        [Required]
        public string name { get; set; }

        [Required]
        public string state { get; set; }

        [Required]
        public string city { get; set; }

        [Required]
        public string address { get; set; }

        public string picture { get; set; }

        public string about { get; set; }

        public int size { get; set; }

        public bool setupFinished { get; set; }

        public int? rating { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<OpenPosition> OpenPositions { get; set; }
    }
}
