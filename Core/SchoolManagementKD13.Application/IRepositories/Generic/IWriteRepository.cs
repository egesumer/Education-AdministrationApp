using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolManagementKD13.Application.IRepositories.Generic
{
    public interface IWriteRepository<T> : IRepository<T> where T : class
    {
        Task<bool> AddAsync(T entity);
        Task<bool> AddRangeAsync(List<T> entities);

        bool Remove(T entity);

        Task<bool> RemoveAsync(Guid id);
        bool RemoveRange(List<T> entities);

        //Unit of Work pattern
        Task<int> SaveAsync();
    }
}
