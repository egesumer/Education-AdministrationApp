using MediatR;
using SchoolManagementKD13.Application.IRepositories;
using SchoolManagementKD13.Application.IServices;
using SchoolManagementKD13.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolManagementKD13.Application.Features.Commands.StudentCreate
{
    public class StudentCreateCommandHandler : IRequestHandler<StudentCreateCommandRequest, CommandResponse>
    {
        readonly IStudentWriteRepository studentWriteRepository;
        readonly IFileService fileService;

        public StudentCreateCommandHandler(IStudentWriteRepository studentWriteRepository, IFileService fileService)
        {
            this.studentWriteRepository = studentWriteRepository;
            this.fileService = fileService;
        }

        public async Task<CommandResponse> Handle(StudentCreateCommandRequest request, CancellationToken cancellationToken)
        {
            CommandResponse commandResponse = new();
            Student student = new();
            student.FirstName = request.StudentCreateDto.FirstName;
            student.LastName = request.StudentCreateDto.LastName;
            if (!string.IsNullOrWhiteSpace(request.StudentCreateDto.SchoolId))
            {
                student.SchoolId = Guid.Parse(request.StudentCreateDto.SchoolId);
            }
            await fileService.SaveStudentPhotoToRootAsync(request.StudentCreateDto, student, request.HttpRequest);
            bool check = await studentWriteRepository.AddAsync(student);
            if (!check)
            {
                commandResponse.Check = check;
                return commandResponse;
            }
            int dbCheck = await studentWriteRepository.SaveAsync();
            if (dbCheck < 1)
            {
                commandResponse.DbCheck = dbCheck;
            }
            return commandResponse;
        }
    }
}
