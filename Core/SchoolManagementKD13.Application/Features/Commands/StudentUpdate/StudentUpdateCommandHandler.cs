using MediatR;
using SchoolManagementKD13.Application.IRepositories;
using SchoolManagementKD13.Application.IServices;
using SchoolManagementKD13.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolManagementKD13.Application.Features.Commands.StudentUpdate
{
    public class StudentUpdateCommandHandler : IRequestHandler<StudentUpdateCommandRequest, CommandResponse>
    {
        readonly IStudentReadRepository studentReadRepository;
        readonly IStudentWriteRepository studentWriteRepository;
        readonly IFileService fileService;

        public StudentUpdateCommandHandler(IStudentReadRepository studentReadRepository, IStudentWriteRepository studentWriteRepository, IFileService fileService)
        {
            this.studentReadRepository = studentReadRepository;
            this.studentWriteRepository = studentWriteRepository;
            this.fileService = fileService;
        }

        public async Task<CommandResponse> Handle(StudentUpdateCommandRequest request, CancellationToken cancellationToken)
        {
            CommandResponse commandResponse = new();
            Student student = await studentReadRepository.GetByIdAsync(request.StudentUpdateDto.Id);
            if (student==null)
            {
                commandResponse.Found = false;
                return commandResponse;
            }
            student.FirstName = request.StudentUpdateDto.FirstName;
            student.LastName = request.StudentUpdateDto.LastName;
            if (!string.IsNullOrWhiteSpace(request.StudentUpdateDto.SchoolId))
            {
                student.SchoolId = Guid.Parse(request.StudentUpdateDto.SchoolId);
            }
            fileService.DeleteStudentOldPhoto(student, request.StudentUpdateDto);
            await fileService.SaveStudentPhotoToRootAsync(request.StudentUpdateDto, student, request.HttpRequest);
            int dbCheck = await studentWriteRepository.SaveAsync();
            if (dbCheck<1)
            {
                commandResponse.DbCheck = dbCheck;
            }
            return commandResponse;
        }
    }
}
