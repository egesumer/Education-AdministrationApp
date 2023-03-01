using SchoolManagementKD13.Application.IRepositories.Generic;
using SchoolManagementKD13.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolManagementKD13.Application.IRepositories
{
    public interface IStudentReadRepository : IReadRepository<Student>
    {
        Task<List<Student>> GetAllIncludeSchoolsAsync(bool tracking = true);
    }
}
