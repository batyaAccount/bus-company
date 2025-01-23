using busCompany.Core.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace busCompany.CORE.IRepository
{
    public interface IBusesRepository
    {
        public IEnumerable<Bus> Get();
        public Bus GetById(int bus);
        public Bus Add(Bus bus);
        public bool Update(int id, Bus bus);
        public void Delete(int id);
        public int indexOf(int id);
    }
}
