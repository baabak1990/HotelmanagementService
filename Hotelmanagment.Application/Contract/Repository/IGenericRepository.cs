using System.Linq.Expressions;
using Hotlemanagment.Domain.Entity.Entities;
using X.PagedList;


namespace Hotelmanagment.Application.Contract.Repository;

public interface IGenericRepository<T> where T : class
{
    Task<IReadOnlyList<T>> GetAllAsync(
        Expression<Func<T, bool>> expression = null,
        Func<IQueryable<T>, IOrderedQueryable<T>> orderby = null,
        List<string> includes = null);

    Task<IPagedList<T>> GetAllWithPaging(RequestParams requestParams, List<string> includes =null);
    Task<T> GetAsync(Expression<Func<T, bool>> expression, List<string> includes = null);
    void UpdateAsync(T entity);
    Task DeleteAsync(int id);
    void DeleteRange(IEnumerable<T> entities);
    Task Add(T entity);
    Task AddRange(IEnumerable<T> entities);
}