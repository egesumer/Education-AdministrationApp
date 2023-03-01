using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolManagementKD13.Application.DTOs
{
	public record ApplicationUserLoginDto
	{
		[Required]
		[EmailAddress]
		public string Email { get; set; }
		[Required]
		[MinLength(5)]
		public string Password { get; set; }
	}
}
