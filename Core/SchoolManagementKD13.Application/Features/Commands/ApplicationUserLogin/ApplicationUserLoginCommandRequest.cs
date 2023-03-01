using MediatR;
using SchoolManagementKD13.Application.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolManagementKD13.Application.Features.Commands.ApplicationUserLogin
{
	public class ApplicationUserLoginCommandRequest : IRequest<string?>
	{
		public ApplicationUserLoginDto applicationUserLoginDto { get; set; }

		public ApplicationUserLoginCommandRequest(ApplicationUserLoginDto applicationUserLoginDto)
		{
			this.applicationUserLoginDto = applicationUserLoginDto;
		}
	}
}
