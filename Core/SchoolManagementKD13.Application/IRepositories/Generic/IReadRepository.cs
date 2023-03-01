using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace SchoolManagementKD13.Application.IRepositories.Generic
{
    public interface IReadRepository<T> : IRepository<T> where T : class
    {
        //async / await Task döner
        Task<List<T>> GetAllAsync(bool tracking = true);
        Task<List<T>> GetWhereAsync(Expression<Func<T,bool>> expression, bool tracking = true);

        Task<T> GetSingleAsync(Expression<Func<T, bool>> expression, bool tracking = true);

        Task<T> GetByIdAsync(Guid Id, bool tracking = true);
    }
}
