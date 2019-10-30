using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace VenitoApi.DTO
{
    public class EmployerResponseDTO
    {
        public int id { get; set; } 
        public string name { get; set; } 
        public string state { get; set; } 
        public string city { get; set; } 
        public string address { get; set; }

        public string picture { get; set; }

        public string about { get; set; }

        public int size { get; set; }

        public bool setupFinished { get; set; }

        public int? rating { get; set; }

        public virtual List<OpenPositionResponseDTO> OpenPositions { get; set; }
    }
    public partial class OpenPositionResponseDTO
    { 
        public int id { get; set; }

        public int employerId { get; set; }

        public int jobId { get; set; } 
        public string description { get; set; }

        public int salaryRangeFrom { get; set; }

        public int salaryRangeTo { get; set; } 
    }
}