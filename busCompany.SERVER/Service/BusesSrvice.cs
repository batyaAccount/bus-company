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
        readonly IBusesRepository _busesRepository;
        public BusesSrvice(IBusesRepository busesRepository)
        {
            _busesRepository = busesRepository;
        }
        public Bus GetBus(int id)
        {
            return _busesRepository.GetByIdBus(id);
        }
        public bool Add(Bus bus)
        {
            if (GetBus(bus.Id) != null)
                return false;
            return _busesRepository.Add(bus);
        }

        public bool DeleteOne(int id)
        {
            return _busesRepository.DeleteBus(id);
        }

        public List<Bus> GetAll()
        {
            return _busesRepository.GetBuses();
        }

        public bool Update(int id, Bus employee)
        {
          
            if (GetAll().Count == 0)
                return false;
            if (_busesRepository.indexOf(id)==-1)
                return false;
            return _busesRepository.Update(id, employee);
        }
    }
}
