using busCompany.Core.Entity;
using busCompany.CORE.IRepository;
using busCompany.CORE.IService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace busCompany.SERVICE.Service
{
    public class BusesSrvice : IBusesService
    {
        readonly IRepositoryMamager _Repository;
        public BusesSrvice(IRepositoryMamager busesRepository)
        {
            _Repository = busesRepository;
        }
        public Bus GetBus(int id)
        {
            return _Repository.Buses.GetByIdBus(id);
        }
        public bool Add(Bus bus)
        {
            if (GetBus(bus.BusId) != null)
                return false;
            bool flag = _Repository.Buses.Add(bus);
            if (flag)
                _Repository.Save();
            return flag;
        }

        public bool DeleteOne(int id)
        {
            bool flag = _Repository.Buses.DeleteBus(id);
            if (flag)
                _Repository.Save();
            return flag;
        }

        public IEnumerable<Bus> GetAll()
        {
            return _Repository.Buses.GetBuses();
        }

        public bool Update(int id, Bus employee)
        {

            if (GetAll().Count() == 0)
                return false;
            if (_Repository.Buses.indexOf(id) == -1)
                return false;
            bool flag = _Repository.Buses.Update(id, employee);
            if (flag)
                _Repository.Save();
            return flag;
        }
    }
}
