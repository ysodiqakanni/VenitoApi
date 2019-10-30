using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using VenitoApi.DTO;

namespace VenitoApi.Controllers
{
    [RoutePrefix("api/v1/employer")]
    public class EmployerController : ApiController
    {
        VenitoDbContext db = new VenitoDbContext();


        [HttpGet]
        [Route("")]
        public IHttpActionResult GetAll()
        {
            var employers = db.Employers.ToList();
            if (employers == null || !employers.Any())
                return Ok();

            var response = GetEmployerResponse(employers);
            return Ok(response);
        }

        [Route("{id?}")]
        public IHttpActionResult GetById(int? id)
        {
            var employer = db.Employers.Find(id);
            if (employer != null)
                return Ok(GetEmployerResponse(employer));
            return Ok(employer);
        }


        private List<EmployerResponseDTO> GetEmployerResponse(List<Employer> employers)
        {
            var result = new List<EmployerResponseDTO>();
            foreach (var item in employers)
            {
                result.Add(GetEmployerResponse(item));
            }
            return result;
        }
        private EmployerResponseDTO GetEmployerResponse(Employer employer)
        {
            var result = new EmployerResponseDTO
            {
                id = employer.id,
                about = employer.about,
                address = employer.address,
                city = employer.city, 
                name = employer.name,
                picture = employer.picture,
                rating = employer.rating,
                setupFinished = employer.setupFinished,
                size = employer.size,
                state = employer.state
            };

            if(employer.OpenPositions != null && employer.OpenPositions.Any())
            {
                var positions = new List<OpenPositionResponseDTO>();
                foreach (var item in employer.OpenPositions)
                {
                    positions.Add(new OpenPositionResponseDTO
                    {
                        id = item.id,
                        description = item.description,
                        salaryRangeFrom = item.salaryRangeFrom,
                        salaryRangeTo = item.salaryRangeTo,
                        jobId = item.jobId,
                        employerId = item.employerId
                    });
                }
                result.OpenPositions = positions;
            }
            return result;
        }
    }
}
