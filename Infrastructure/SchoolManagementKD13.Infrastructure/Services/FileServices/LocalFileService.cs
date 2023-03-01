using Microsoft.AspNetCore.Hosting;
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
    public class LocalFileService : ILocalFileService
    {
        readonly IWebHostEnvironment webHostEnvironment;

        public void DeleteStudentOldPhoto(Student student, StudentUpdateDto studentUpdateDto)
        {
            if(student.PhotoPath != null && studentUpdateDto.Photo!= null)
            {
                File.Delete(student.PhotoPath);
            }
        }

        public void DeleteStudentPhoto(Student student)
        {
            if (student.PhotoPath!=null)
            {
                File.Delete(student.PhotoPath);
            }
        }

        
        public async Task SaveStudentPhotoToRootAsync(StudentCreateDto studentCreateDto, Student student, HttpRequest request)
        {
            if(studentCreateDto.Photo==null)
            {
                return;
            }
            string ticks = DateTime.Now.Ticks.ToString();
            var path = webHostEnvironment.WebRootPath + @"\images\" + ticks + Path.GetExtension(studentCreateDto.Photo.FileName);

            await using(var stream = new FileStream(path, FileMode.Create))
            {
                await studentCreateDto.Photo.CopyToAsync(stream);
            }
            student.PhotoPath = "https://" + request.Host + @"/images/" + ticks + Path.GetExtension(studentCreateDto.Photo.FileName);
        }
    }
}
