using MediatR;
using Microsoft.AspNetCore.Http;
using SchoolManagementKD13.Application.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolManagementKD13.Application.Features.Commands.StudentUpdate
{
    public class StudentUpdateCommandRequest : IRequest<CommandResponse>
    {
        public StudentUpdateDto StudentUpdateDto { get; set; }
        public HttpRequest HttpRequest { get; set; }

        public StudentUpdateCommandRequest(StudentUpdateDto studentUpdateDto, HttpRequest httpRequest)
        {
            StudentUpdateDto = studentUpdateDto;
            HttpRequest = httpRequest;
        }
    }
}
