using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace VenitoApi.DTO
{
    public class EmployeeResponseDTO
    {
        public int id { get; set; } 
        public string name { get; set; } 
        public string surname { get; set; } 
        public string state { get; set; } 
        public string city { get; set; }

        public string picture { get; set; }

        public string education { get; set; }

        public string about { get; set; }

        public bool status { get; set; }

        public bool setupFinished { get; set; }

        public int? rating { get; set; }
        public List<EmployeeHistoryResponseDTO> EmployeeHistories { get; set; }
        public List<EmployeeFollowingResponseDTO> EmployeeFollowings { get; set; }
    }
    public partial class EmployeeHistoryResponseDTO
    { 
        public int id { get; set; } 
        public string company { get; set; } 
        public string position { get; set; }

        public int yearFrom { get; set; }

        public int? yearTo { get; set; }

        public bool present { get; set; }

        //public int employeeId { get; set; } 
    }
    public partial class EmployeeFollowingResponseDTO
    { 
        public int id { get; set; }

        public int jobId { get; set; }

        public int employeeId { get; set; } 
    }
}