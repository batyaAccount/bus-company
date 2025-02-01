using AutoMapper;
using busCompany.Core.Entity;
using busCompany.CORE.DTOs;
using busCompany.CORE.IRepository;
using busCompany.CORE.IService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace busCompany.SERVICE.Service
{
    public class StationsService : IStationsService
    {
        readonly IRepositoryMamager _repositoryMamager;
        readonly IStationRepository _stationRepository;
        readonly IMapper _mapper;

        public StationsService(IRepositoryMamager repositoryMamager, IStationRepository stationRepository,IMapper mapper)
        {
            _repositoryMamager = repositoryMamager;
            _stationRepository = stationRepository;
            _mapper = mapper;
        }
        public Station Add(Station station)
        {
            if (GetStation(station.Id) != null)
                return null;
            _stationRepository.Add(station);
            _repositoryMamager.Save();
            return station;
        }

        public bool DeleteOne(int id)
        {
            if(_stationRepository.indexOf(id) == -1)
                return false;
            _stationRepository.Delete(id);
            _repositoryMamager.Save();
            return true;
        }

        public IEnumerable<StationDto> GetAll()
        {
            var stations = _stationRepository.Get().ToList();
            return _mapper.Map<IEnumerable<StationDto>>(stations);   
        }

        public StationDto GetStation(int id)
        {
            var station = _stationRepository.GetById(id);
            return _mapper.Map<StationDto>(station);
        }

        public bool Update(int id, Station station)
        {
          
            if (  GetAll().Count() == 0)
                return false;
            if (_stationRepository.indexOf(id) == -1)
                return false;
            bool flag = _stationRepository.Update(id,station);
            if(flag)
                _repositoryMamager.Save();
            return flag;
        }
    }
}
