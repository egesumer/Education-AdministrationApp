using Microsoft.AspNetCore.Http;
using SchoolManagementKD13.Application.DTOs;
using SchoolManagementKD13.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolManagementKD13.Application.IServices
{
    public interface IBaseFileService
    {
        Task SaveStudentPhotoToRootAsync(StudentCreateDto studentCreateDto, Student student, HttpRequest request);

        void DeleteStudentOldPhoto(Student oldStudent, StudentUpdateDto studentUpdateDto);
        void DeleteStudentPhoto(Student student);
    }
}
