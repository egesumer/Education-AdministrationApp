using MediatR;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SchoolManagementKD13.Application.DTOs;
using SchoolManagementKD13.Application.Features.Queries.GetAllSchools;
using SchoolManagementKD13.Application.IRepositories;
using SchoolManagementKD13.Domain;

namespace SchoolManagementKD13.MVCUI.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class SchoolsController : ControllerBase
	{
		private readonly ISchoolReadRepository schoolReadRepository;
		readonly IMediator mediator;

		public SchoolsController(ISchoolReadRepository schoolReadRepository, IMediator mediator)
		{
			this.schoolReadRepository = schoolReadRepository;
			this.mediator = mediator;
		}

		[HttpGet]
		[Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
		public async Task<IActionResult> Get()
		{
			List<School> schools = await mediator.Send(new GetAllSchoolsQueryRequest());

			SchoolIndexVM schoolIndexVM = new();
			schoolIndexVM.Schools = schools;

			return Ok(schoolIndexVM);
		}
	}
}
