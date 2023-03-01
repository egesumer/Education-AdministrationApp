using MediatR;
using Microsoft.AspNetCore.Http;
using SchoolManagementKD13.Application.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolManagementKD13.Application.Features.Commands.StudentCreate
{
    //Mediator pattern
    public class StudentCreateCommandRequest : IRequest<CommandResponse>
    {
        public StudentCreateDto StudentCreateDto { get; set; }
        public HttpRequest HttpRequest { get; set; }
        public StudentCreateCommandRequest(StudentCreateDto studentCreateDto, HttpRequest httpRequest)
        {
            StudentCreateDto = studentCreateDto;
            HttpRequest = httpRequest;
        }
    }
}
