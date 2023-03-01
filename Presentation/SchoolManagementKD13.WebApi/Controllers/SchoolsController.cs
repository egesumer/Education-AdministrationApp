using MediatR;
using Microsoft.AspNetCore.Mvc;
using SchoolManagementKD13.Application.DTOs;
using SchoolManagementKD13.Application.Features.Queries.GetAllSchools;
using SchoolManagementKD13.Application.IRepositories;
using SchoolManagementKD13.Domain;
using SchoolManagementKD13.Persistence.Repositories;
using System.Net;

namespace SchoolManagementKD13.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SchoolsController : Controller
    {
        private readonly ISchoolReadRepository schoolReadRepository;
        private readonly ISchoolWriteRepository schoolWriteRepository;

        readonly IMediator mediator;
        public SchoolsController(ISchoolReadRepository schoolReadRepository, ISchoolWriteRepository schoolWriteRepository, IMediator mediator)
        {
            this.schoolReadRepository = schoolReadRepository;
            this.schoolWriteRepository = schoolWriteRepository;
            this.mediator = mediator;
        }

        [HttpGet]
        public async Task <IActionResult> Get()
        {
            //List<School> schools = await schoolReadRepository.GetAllAsync(false);

            List<School> schools = await mediator.Send(new GetAllSchoolsQueryRequest());
            return Ok(schools);
        }

        [HttpPost]
        public async Task <IActionResult> Post([FromForm] SchoolCreateDto schoolCreateDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            School school = new School();
            school.Students = schoolCreateDto.Students.ToList();
            school.Name = schoolCreateDto.Name;
            school.Id = Guid.NewGuid();
            school.CreationDate= DateTime.Now;
            school.UpdateDate = DateTime.Now;
            bool check = await schoolWriteRepository.AddAsync(school);
            if (!check) return StatusCode((int)HttpStatusCode.InternalServerError);
            int dbCheck = await schoolWriteRepository.SaveAsync();
            return dbCheck > 0 ? Ok(school) : BadRequest();
        }

        [HttpDelete]
        public async Task<IActionResult> Delete([FromForm] Guid Id)
        {
            School school = await schoolReadRepository.GetByIdAsync(Id);
            if (school == null)
            {
                return NotFound();
            }
            bool check = await schoolWriteRepository.RemoveAsync(school.Id);
            int dbCheck = await schoolWriteRepository.SaveAsync();
            return dbCheck > 0 ? Ok(school) : StatusCode((int)HttpStatusCode.InternalServerError);
        }



        //[HttpPut]
        //public async Task<IActionResult> Update([FromForm] SchoolUpdateDTO schoolUpdateDTO)
        //{
        //    School school = await schoolReadRepository.GetById(schoolUpdateDTO.Id);
        //    school.Name = schoolUpdateDTO.Name;
        //    school.Id= schoolUpdateDTO.Id;

        //    if (!ModelState.IsValid)
        //    {
        //        return BadRequest();
        //    }
        //    bool check = schoolWriteRepository.Update(school);
        //    if (!check)
        //    {
        //      return StatusCode((int)HttpStatusCode.InternalServerError);
        //    }
        //    int dbCheck = await schoolWriteRepository.SaveAsync();
        //    return dbCheck > 0 ? Ok(school) : BadRequest();
        //}
    }
}
