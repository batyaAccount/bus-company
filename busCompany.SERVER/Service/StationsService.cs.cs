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
        readonly IStationRepository _stationRepository;
        public StationsService(IStationRepository stationRepository)
        {
            _stationRepository = stationRepository;
        }
        public bool Add(Station station)
        {
            if (GetStation(station.Id) != null)
                return false;
            return  _stationRepository.Add(station);
        }

        public bool DeleteOne(int id)
        {
            return _stationRepository.DeleteStation(id);
        }

        public List<Station> GetAll()
        {
            return _stationRepository.GetStations();
        }

        public Station GetStation(int id)
        {
            return _stationRepository.getByIdStation(id);
        }

        public bool Update(int id, Station station)
        {
          
            if (  GetAll().Count == 0)
                return false;
            if (_stationRepository.indexOf(id) == -1)
                return false;
            return _stationRepository.Update(id,station);
        }
    }
}
