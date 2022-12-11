using System.Linq.Expressions;

namespace SimpleProject.Interfaces
{

    public interface IRepositoryBase<T>
    {
        void Create(T entity);
        Task CreateAsync(T entity);
        IQueryable<T> FindByCondition(Expression<Func<T, bool>> expression);
        void Update(T entity);
        void Delete(T entity);
        void SaveChanges();
    }
}
