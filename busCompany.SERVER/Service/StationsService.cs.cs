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
        readonly IRepositoryMamager _stationRepository;
        public StationsService(IRepositoryMamager stationRepository)
        {
            _stationRepository = stationRepository;
        }
        public bool Add(Station station)
        {
            if (GetStation(station.Id) != null)
                return false;
            bool flag = _stationRepository.Stations.Add(station);
            if (flag)
                _stationRepository.Save();
            return flag;
        }

        public bool DeleteOne(int id)
        {
            bool flag = _stationRepository.Stations.DeleteStation(id);
            if(flag)
                _stationRepository.Save();
            return flag;
        }

        public IEnumerable<Station> GetAll()
        {
            return _stationRepository.Stations.GetStations();
        }

        public Station GetStation(int id)
        {
            return _stationRepository.Stations.getByIdStation(id);
        }

        public bool Update(int id, Station station)
        {
          
            if (  GetAll().Count() == 0)
                return false;
            if (_stationRepository.Stations.indexOf(id) == -1)
                return false;
            bool flag = _stationRepository.Stations.Update(id,station);
            if(flag)
                _stationRepository.Save();
            return flag;
        }
    }
}
