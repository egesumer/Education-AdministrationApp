using SchoolManagementKD13.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolManagementKD13.Application.DTOs
{
	public record SchoolIndexVM
	{
		public List<School> Schools { get; set; } = new List<School>();

	}
}
