using MediatR;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SchoolManagementKD13.Application.DTOs;
using SchoolManagementKD13.Application.Features.Commands.ApplicationUserCreate;
using SchoolManagementKD13.Application.Features.Commands.ApplicationUserLogin;
using System.Security.Claims;

namespace SchoolManagementKD13.WebApi.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class ApplicationUsersController : ControllerBase
	{
		readonly IMediator mediator;

		public ApplicationUsersController(IMediator mediator)
		{
			this.mediator = mediator;
		}

		[HttpPost]
		[AllowAnonymous]
		public async Task<IActionResult> Create([FromForm] ApplicationUserCreateDto applicationUserCreateDto)
		{
			if (!ModelState.IsValid)
			{
				return BadRequest();
			}

			ApplicationUserCreateCommandResponse applicationUserCreateCommandResponse = await mediator.Send(new ApplicationUserCreateCommandRequest(applicationUserCreateDto));

			if (applicationUserCreateCommandResponse.Succeeded == false)
			{
				return new BadRequestObjectResult(applicationUserCreateCommandResponse.Message);
			}

			return Ok(applicationUserCreateCommandResponse.Message);
		}

		[HttpPost("[action]")]
		[AllowAnonymous]
		public async Task<IActionResult> Login([FromForm] ApplicationUserLoginDto applicationUserLoginDto)
		{
			if (!ModelState.IsValid)
			{
				return BadRequest();
			}

			string? token = await mediator.Send(new ApplicationUserLoginCommandRequest(applicationUserLoginDto));

			if (token == null)
			{
				return NotFound();
			}
			return Ok(token);


		}
		[HttpGet]
		[Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
		public IActionResult GetLoggedInUserRole()
		{
			var role = User.FindFirstValue("Role");
			return Ok(role);
		}
	}
}
