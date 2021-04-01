using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace AspNetCoreHero.Boilerplate.Application.Interfaces.Repositories
{
    public interface IRepositoryBase<T> where T : class
    {
        IQueryable<T> Entities { get; }

        IQueryable<T> FindByCondition(Expression<Func<T, bool>> expression);

        Task<List<T>> FindAll();

        Task<List<T>> GetPagedReponseAsync(int pageNumber, int pageSize);

        Task<T> Create(T entity);

        Task Update(T entity);

        Task Delete(T entity);
    }
}