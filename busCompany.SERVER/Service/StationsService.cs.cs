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
    public class StationsService : IStationsService
    {
        readonly IRepositoryMamager _repositoryMamager;
        readonly IStationRepository _stationRepository;
        public StationsService(IRepositoryMamager repositoryMamager, IStationRepository stationRepository)
        {
            _repositoryMamager = repositoryMamager;
            _stationRepository = stationRepository;
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

        public IEnumerable<Station> GetAll()
        {
            return _stationRepository.Get().ToList();
        }

        public Station GetStation(int id)
        {
            return _stationRepository.GetById(id);
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
