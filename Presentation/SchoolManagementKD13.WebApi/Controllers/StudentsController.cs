using MediatR;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SchoolManagementKD13.Application.DTOs;
using SchoolManagementKD13.Application.Features.Commands;
using SchoolManagementKD13.Application.Features.Commands.StudentCreate;
using SchoolManagementKD13.Application.Features.Commands.StudentUpdate;
using SchoolManagementKD13.Application.Features.Queries.GetAllStudentsWithSchools;
using SchoolManagementKD13.Application.IRepositories;
using SchoolManagementKD13.Domain;
using SchoolManagementKD13.MVCUI.Models;
using System.Net;
using System.Security.Claims;

namespace SchoolManagementKD13.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentsController : ControllerBase
    {
        private readonly IStudentReadRepository studentReadRepository;
        private readonly IStudentWriteRepository studentWriteRepository;

        readonly IMediator mediator;


        public StudentsController(IStudentReadRepository studentReadRepository, IMediator mediator)
        {
            this.studentReadRepository = studentReadRepository;
            this.studentWriteRepository = studentWriteRepository;
            this.mediator = mediator;
        }

     

        [HttpGet] // belirtilmesi gerek.
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public async Task<IActionResult> Get()
        {
            // List<Student> students = await studentReadRepository.GetAllAsync(false);
            List<Student> students = await mediator.Send(new GetAllStudentsQueryRequest());

            var role = User.FindFirstValue("Role");
            var email = User.FindFirstValue("Email");
            StudentsIndexVM studentsIndexVM = new();
            studentsIndexVM.Students = students;
            studentsIndexVM.LoggedInUserRole = role;
            studentsIndexVM.LoggedInUserEmail = email;
            return Ok(students);
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromForm]StudentCreateDto studentCreateDto)
        {
            if(!ModelState.IsValid)
            {
                return BadRequest();
            }

            CommandResponse commandResponse = await mediator.Send(new StudentCreateCommandRequest(studentCreateDto,Request));
            
   
            if (commandResponse.Check == false) return BadRequest();
            if (commandResponse.DbCheck < 1) return StatusCode((int)HttpStatusCode.InternalServerError);
            return StatusCode((int)HttpStatusCode.Created);
        }

        [HttpPut]
        public async Task<IActionResult> Put([FromForm] StudentUpdateDto studentUpdateDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            CommandResponse commandResponse = await mediator.Send(new StudentUpdateCommandRequest(studentUpdateDto, Request));
            if (commandResponse.Found == false) return NotFound();
            if (commandResponse.DbCheck < 1) return StatusCode((int)HttpStatusCode.InternalServerError);
            return Ok();


        }


    }
}
