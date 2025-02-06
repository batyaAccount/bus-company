using busCompany.Core.Entity;
using busCompany.CORE.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace busCompany.CORE.IService
{
    public interface IBusesService
    {

        public IEnumerable<BusDto> GetAll();
        public BusDto GetBus(int id);
        public BusDto Add(BusDto employee);
        public bool Update(int id, BusDto employee);
        public bool DeleteOne(int id);
    }
}
