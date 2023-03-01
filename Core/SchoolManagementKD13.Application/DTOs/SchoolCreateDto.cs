using SchoolManagementKD13.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolManagementKD13.Application.DTOs
{
    public record SchoolCreateDto
    {
        public string Name { get; set; }
        public IEnumerable<Student>? Students { get; set; }
    }
}
