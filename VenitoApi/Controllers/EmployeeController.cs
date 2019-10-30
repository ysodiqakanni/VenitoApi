using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using VenitoApi.DTO;

namespace VenitoApi.Controllers
{
    [RoutePrefix("api/v1/employee")]
    public class EmployeeController : ApiController
    {
        VenitoDbContext db = new VenitoDbContext();


        [HttpGet]
        [Route("")]
        public IHttpActionResult GetAll()
        {
            var employees = db.Employees.ToList();
            if (employees == null || !employees.Any())
                return Ok();

            var response = GetEmployeeResponse(employees);
            return Ok(response);
        }

        [Route("{id?}")]
        public IHttpActionResult GetById(int? id)
        {
            var employee = db.Employees.Find(id);
            if (employee != null)
                return Ok(GetEmployeeResponse(employee));
            return Ok(employee);
        }

        private EmployeeResponseDTO GetEmployeeResponse(Employee employee)
        {
            var result = new EmployeeResponseDTO
            {
                id = employee.id,
                name = employee.name,
                about = employee.about,
                city = employee.city,
                education = employee.education,
                picture = employee.picture,
                rating = employee.rating,
                setupFinished = employee.setupFinished,
                state = employee.state,
                status = employee.status,
                surname = employee.surname
            };

            // get history
            if(employee.EmployeeHistories != null && employee.EmployeeHistories.Any())
            {
                var histories = new List<EmployeeHistoryResponseDTO>();
                foreach (var item in employee.EmployeeHistories)
                {
                    histories.Add(new DTO.EmployeeHistoryResponseDTO
                    {
                        id = item.id,
                        company = item.company,
                        position = item.position,
                        present = item.present,
                        yearFrom = item.yearFrom,
                        yearTo = item.yearTo
                    });
                }
                result.EmployeeHistories = histories;
            }
            // get following
            if (employee.EmployeeFollowings != null && employee.EmployeeFollowings.Any())
            {
                var followings = new List<EmployeeFollowingResponseDTO>();
                foreach (var item in employee.EmployeeFollowings)
                {
                    followings.Add(new EmployeeFollowingResponseDTO
                    {
                        id = item.id,
                        employeeId = item.employeeId,
                        jobId = item.jobId
                    });
                }
                result.EmployeeFollowings = followings;
            }

                return result;
        }
        private List<EmployeeResponseDTO> GetEmployeeResponse(List<Employee> employees)
        {
            var result = new List<EmployeeResponseDTO>();
            foreach (var item in employees)
            {
                result.Add(GetEmployeeResponse(item));
            }
            return result;
        }
    }
}
