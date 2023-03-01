using Microsoft.AspNetCore.Hosting;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolManagementKD13.Application.DTOs
{
    public record StudentUpdateDto : StudentCreateDto
    {

        [Required]
        public Guid Id { get; set; }

        private string photoPath;

        public StudentUpdateDto()
        {
        }

        public string? PhotoPath
        {
            get { return photoPath; }
            set
            {
                if (value == null) return;
                string[] arr = value.Split("images/");
                photoPath = Path.Combine(Directory.GetCurrentDirectory(), "../../Presentation/SchoolManagementKD13.WebApi/wwwroot/images/") + arr[1];
            }
        }
    }
}
