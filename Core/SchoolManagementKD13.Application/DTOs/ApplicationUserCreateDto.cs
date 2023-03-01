﻿using SchoolManagementKD13.Domain.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolManagementKD13.Application.DTOs
{
	public record ApplicationUserCreateDto
	{
		[Required]
		[MaxLength(50)]
		public string UserName { get; set; }
		[Required]
		[MaxLength(50)]
		public string FirstName { get; set; }
		[Required]
		[MaxLength(50)]
		public string LastName { get; set; }
		[Required]
		[MinLength(5)]
		public string Password { get; set; }
		[Required]
		[Compare("Password")]
		public string PasswordConfirm { get; set; }
		[Required]
		[EmailAddress]
		public string Email { get; set; }
		[Required]
		public ApplicationUserRole ApplicationUserRole { get; set; }
	}
}
