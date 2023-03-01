using Microsoft.EntityFrameworkCore;
using SchoolManagementKD13.Application.IRepositories;
using SchoolManagementKD13.Domain;
using SchoolManagementKD13.Persistence.Contexts;
using SchoolManagementKD13.Persistence.Repositories.Generic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace SchoolManagementKD13.Persistence.Repositories
{
    public class StudentReadRepository : ReadRepository<Student>, IStudentReadRepository
    {
        private readonly SchoolManagementDbContext context;
        public StudentReadRepository(SchoolManagementDbContext context) : base(context)
        {
            this.context = context;
        }

        public async Task<List<Student>> GetAllIncludeSchoolsAsync(bool tracking = true)
        {
            var query = Table.Include(s => s.School).AsQueryable();
            if (!tracking) query = query.AsNoTracking();
            return await query.ToListAsync();
        }
    }
}
