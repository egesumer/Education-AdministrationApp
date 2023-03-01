using MediatR;
using Microsoft.AspNetCore.Identity;
using SchoolManagementKD13.Application.IToken;
using SchoolManagementKD13.Domain.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolManagementKD13.Application.Features.Commands.ApplicationUserLogin
{
	public class ApplicationUserLoginCommandHandler : IRequestHandler<ApplicationUserLoginCommandRequest, string?>
	{
		readonly UserManager<ApplicationUser> userManager;
		readonly SignInManager<ApplicationUser> signInManager;
		readonly ITokenHandler tokenHandler;

		public ApplicationUserLoginCommandHandler(UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager, ITokenHandler tokenHandler)
		{
			this.userManager = userManager;
			this.signInManager = signInManager;
			this.tokenHandler = tokenHandler;
		}

		public async Task<string?> Handle(ApplicationUserLoginCommandRequest request, CancellationToken cancellationToken)
		{
			ApplicationUser applicationUser = await userManager.FindByEmailAsync(request.applicationUserLoginDto.Email);
			if (applicationUser == null)
			{
				return null;
			}
			SignInResult signInResult = await signInManager.CheckPasswordSignInAsync(applicationUser, request.applicationUserLoginDto.Password, false);

			if (!signInResult.Succeeded)
			{
				return null;
			}

			//Bu noktada authentication başarılı
			//Yetkilendirip tokeni döndür

			string token = tokenHandler.GenereteJwtToken(applicationUser.Email, applicationUser.ApplicationUserRole.ToString());
			return token;
		}
	}
}
