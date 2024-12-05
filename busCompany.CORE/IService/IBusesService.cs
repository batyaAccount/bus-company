using busCompany.Core.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace busCompany.CORE.IService
{
    public interface IBusesService
    {

        public List<Bus> GetAll();
        public Bus GetBus(int id);
        public bool Add(Bus employee);
        public bool Update(int id, Bus employee);
        public bool DeleteOne(int id);
    }
}
