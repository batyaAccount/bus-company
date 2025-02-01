using AutoMapper;
using busCompany.Core.Entity;
using busCompany.CORE.DTOs;
using busCompany.CORE.IRepository;
using busCompany.CORE.IService;


namespace busCompany.SERVICE.Service
{
    public class BusesSrvice : IBusesService
    {
        readonly IRepositoryMamager _Repository;
        readonly IBusesRepository _busesRepository;
        readonly IMapper _mapper;
        public BusesSrvice(IRepositoryMamager busesRepository,IBusesRepository busesRepository1,IMapper mapper)
        {
            _Repository = busesRepository;
            _busesRepository = busesRepository1;
            _mapper = mapper;
        }
        public BusDto GetBus(int id)
        {
            var bus = _busesRepository.GetById(id);
            return _mapper.Map<BusDto>(bus);
        }
        public Bus Add(Bus bus)
        {
            if (GetBus(bus.BusId) != null)
                return null;
            _Repository.Buses.Add(bus);
                _Repository.Save();
            return bus;
        }

        public bool DeleteOne(int id)
        {
            if(_busesRepository.indexOf(id) == -1)
                return false;
            _busesRepository.Delete(id);
            _Repository.Save();
            return true;
        }

        public IEnumerable<BusDto> GetAll()
        {
            var buses = _busesRepository.Get().ToList();
            return _mapper.Map<IEnumerable<BusDto>>(buses);
        }

        public bool Update(int id, Bus employee)
        {

            if (GetAll().Count() == 0)
                return false;
            if (_busesRepository.indexOf(id) == -1)
                return false;
            bool flag = _busesRepository.Update(id, employee);
            if (flag)
                _Repository.Save();
            return flag;
        }
    }
}
