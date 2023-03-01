using SchoolManagementKD13.Application.IRepositories;
using SchoolManagementKD13.Domain;
using SchoolManagementKD13.Persistence.Contexts;
using SchoolManagementKD13.Persistence.Repositories.Generic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolManagementKD13.Persistence.Repositories
{
    public class StudentWriteRepository : WriteRepository<Student>, IStudentWriteRepository
    {
        private readonly SchoolManagementDbContext context;
        public StudentWriteRepository(SchoolManagementDbContext context) : base(context)
        {
            this.context = context;
        }
    }
}
