using Microsoft.EntityFrameworkCore;
using SchoolManagementKD13.Application.IRepositories.Generic;
using SchoolManagementKD13.Domain.Common;
using SchoolManagementKD13.Persistence.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace SchoolManagementKD13.Persistence.Repositories.Generic
{
    public class ReadRepository<T> : IReadRepository<T> where T : BaseEntity
    {
        readonly SchoolManagementDbContext context;

        public ReadRepository(SchoolManagementDbContext context)
        {
            this.context = context;
        }

        public DbSet<T> Table => context.Set<T>();

        public async Task<T> GetByIdAsync(Guid Id, bool tracking = true)
        {
            var query = Table.AsQueryable();
            if (!tracking) query = query.AsNoTracking();
            return await query.FirstOrDefaultAsync(entity => entity.Id == Id);
        }

        public async Task<List<T>> GetAllAsync(bool tracking = true)
        {
            var query = Table.AsQueryable();
            if (!tracking) query = query.AsNoTracking();
            return await query.ToListAsync();           
        }

        public async Task<T> GetSingleAsync(Expression<Func<T, bool>> expression, bool tracking = true)
        {
            var query = Table.AsQueryable();
            if (!tracking) query = query.AsNoTracking();
            return await query.FirstOrDefaultAsync(expression);
        }

        public async Task<List<T>> GetWhereAsync(Expression<Func<T, bool>> expression, bool tracking = true)
        {
            var query = Table.Where(expression);
            if(!tracking) query = query.AsNoTracking();
            return await query.ToListAsync();
        }


    }
}
