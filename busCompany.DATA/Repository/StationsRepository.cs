using busCompany.Core.Entity;
using busCompany.CORE.IRepository;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace busCompany.DATA.Repository
{
    public class StationsRepository:IStationRepository
    {
        readonly DataContext _context;
        public StationsRepository(DataContext context)
        {
            _context = context;
        }
        public List<Station> GetStations() { return _context.Stations.ToList(); }
        public Station getByIdStation(int id)
        {

            return _context.Stations.ToList().Find(z => z.Id == id);

        }
        public bool Add(Station station)
        {
            
            try
            {
                _context.Stations.Add(station);
                _context.SaveChanges();
              
                return true;
            }
            catch
            {
                return false;

            }

        }
        public bool Update(int id, Station station)
        {
            //The validate checking was done in the service
            Station station1 = _context.Stations.ToList().Find(b => b.Id == id);

            _ = station.GpsWaypoint != station1.GpsWaypoint && station.GpsWaypoint != null?
              station1.GpsWaypoint = station.GpsWaypoint : station1.GpsWaypoint = station1.GpsWaypoint;

            _ = station.Name != station1.Name && station.Name != null ?
              station1.Name = station.Name : station1.Name = station1.Name;

            _ = station.Street != station1.Street && station.Street != null ?
              station1.Street = station.Street : station1.Street = station1.Street;

            _ = station.City != station1.City && station.City != null ?
              station1.City = station.City : station1.City = station1.City;

            _ = station.StationNumber != station1.StationNumber && station.StationNumber != 0 ?
              station1.StationNumber = station.StationNumber : station1.StationNumber = station1.StationNumber;

            _ = station.Type != station1.Type && station.Type != null ?
              station1.Type = station.Type : station1.Type = station1.Type;
            _context.SaveChanges();

            return true;
        }
        public bool DeleteStation(int id)
        {
            List<Station> l = _context.Stations.ToList();

            Station station = l.FirstOrDefault(e => e.Id == id);

            if (station != null)
            {
                _context.Stations.Remove(station);
                _context.SaveChanges();
                return true;
            }

            return false;

        }
        public int indexOf(int id)
        {
            return _context.Stations.ToList().FindIndex(b => b.Id == id);
        }
    }
}
