using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace busCompany.CORE.IRepository
{
    public interface IRepository<T> where T : class
    {
        public  IEnumerable<T> Get();
        T? GetById(int id);
        T Add(T entity);
        void Delete(int id);
    }
}
