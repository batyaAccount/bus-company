using busCompany.Core.Entity;
using busCompany.CORE.IRepository;
using System;
using System.Collections.Generic;
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
        public List<Station> GetStations() { return _context.Stations; }
        public Station getByIdStation(int id)
        {

            return _context.Stations.Find(z => z.Id == id);

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
            Station s = _context.Stations.Find(b => b.Id == id);
            if (s == null)
                return false;
            DeleteStation(id);
            s.StationNumber = station.StationNumber;
            s.Street = station.Street;
            s.City = station.City;
            s.Name = station.Name;
            s.GpsWaypoint = station.GpsWaypoint;
            s.Id = id;
            s.Type = station.Type;


            if (Add(s))
                return true;
            return false;
        }
        public bool DeleteStation(int id)
        {
            List<Station> l = _context.Stations;

            Station station = l.FirstOrDefault(e => e.Id == id);

            if (station != null)
            {
                _context.Stations.Remove(station);
                _context.SaveChanges();
                return true;
            }

            return false;

        }
    }
}
