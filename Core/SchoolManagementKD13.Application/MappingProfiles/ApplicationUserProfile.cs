using AutoMapper;
using SchoolManagementKD13.Application.DTOs;
using SchoolManagementKD13.Domain.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolManagementKD13.Application.MappingProfiles
{
	public class ApplicationUserProfile : Profile
	{
		public ApplicationUserProfile()
		{
			CreateMap<ApplicationUser, ApplicationUserCreateDto>().ReverseMap().ForAllMembers(x => x.UseDestinationValue());
		}
	}
}
