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
        public IEnumerable<Bus> GetBuses();
        public Bus GetByIdBus(int bus);
        public bool Add(Bus bus);
        public bool Update(int id, Bus bus);
        public bool DeleteBus(int id);
        public int indexOf(int id);
    }
}
