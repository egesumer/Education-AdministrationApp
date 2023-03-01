using Microsoft.AspNetCore.Http;
using SchoolManagementKD13.Application.DTOs;
using SchoolManagementKD13.Application.IServices;
using SchoolManagementKD13.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolManagementKD13.Infrastructure.Services.FileServices
{
    public class FileService : IFileService
    {
        readonly IBaseFileService baseFileService;

        public FileService(IBaseFileService baseFileService)
        {
            this.baseFileService = baseFileService;
        }

        public void DeleteStudentOldPhoto(Student oldStudent, StudentUpdateDto studentUpdateDto)
        {
            baseFileService.DeleteStudentOldPhoto(oldStudent,studentUpdateDto);
        }

        public void DeleteStudentPhoto(Student student)
        {
            baseFileService.DeleteStudentPhoto(student);
        }

        public async Task SaveStudentPhotoToRootAsync(StudentCreateDto studentCreateDto, Student student, HttpRequest request)
        {
           await baseFileService.SaveStudentPhotoToRootAsync(studentCreateDto, student, request);    
        }
    }
}
