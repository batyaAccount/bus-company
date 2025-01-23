using busCompany.CORE.IRepository;
using Microsoft.EntityFrameworkCore;

namespace busCompany.DATA.Repository
{
    public class Repository<T> : IRepository<T> where T : class
    {
        protected readonly DbSet<T> _dbSet;
        public Repository(DataContext context)
        {
            _dbSet = context.Set<T>();
        }
        public virtual IEnumerable<T> Get() { return _dbSet; }
        public T GetById(int id)
        {

            return _dbSet.Find(id);

        }
        public T Add(T entity)
        {
            _dbSet.Add(entity);
            return entity;
        }

        public void Delete(int id)
        {
            _dbSet.Remove(GetById(id));

        }
       

    }
}
