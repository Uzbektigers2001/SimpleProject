using SimpleProject.Interfaces;
using System.Linq.Expressions;

namespace SimpleProject.Data.Repositories
{
    public class RepositoryBase<T> : IRepositoryBase<T> where T : class
    {
        private readonly ApplicationDBContext dbcontext;

        public RepositoryBase(ApplicationDBContext dbcontext)
        {
            this.dbcontext = dbcontext ?? throw new ArgumentNullException(nameof(dbcontext));
        }
        public void Create(T entity)
            => dbcontext.Set<T>().Add(entity);

        public async Task CreateAsync(T entity)
            => await dbcontext.Set<T>().AddAsync(entity);

        public IQueryable<T> FindByCondition(Expression<Func<T, bool>> expression)
            => dbcontext.Set<T>().Where(expression);

        public void Update(T entity)
            => dbcontext.Set<T>().Update(entity);

        public void Delete(T entity)
            => dbcontext.Set<T>().Remove(entity);

        public void SaveChanges()
            => dbcontext.SaveChanges();
    }
}
