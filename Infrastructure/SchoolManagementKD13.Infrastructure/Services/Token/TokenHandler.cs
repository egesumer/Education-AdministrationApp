using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using SchoolManagementKD13.Application.IToken;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace SchoolManagementKD13.Infrastructure.Services.Token
{
	public class TokenHandler : ITokenHandler
	{
		readonly IConfiguration configuration;

		public TokenHandler(IConfiguration configuration)
		{
			this.configuration = configuration;
		}

		public string GenereteJwtToken(string email, string role)
		{
			//50 dakikalık jwt
			var tokenHandler = new JwtSecurityTokenHandler();
			var key = Encoding.UTF8.GetBytes(configuration["Token:SecurityKey"]);
			var tokenDescriptor = new SecurityTokenDescriptor
			{
				Audience = configuration["Token:Audience"],
				Issuer = configuration["Token:Issuer"],
				Subject = new ClaimsIdentity(new[] { new Claim("Role", role), new Claim("Email", email) }),
				Expires = DateTime.UtcNow.AddMinutes(50),
				SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
			};
			var token = tokenHandler.CreateToken(tokenDescriptor);
			return tokenHandler.WriteToken(token);
		}
	}
}
