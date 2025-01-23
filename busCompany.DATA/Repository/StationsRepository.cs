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
    public class StationsRepository:Repository<Station>, IStationRepository
    {
        public StationsRepository(DataContext context):base(context)
        {
        }
        public bool Update(int id, Station station)
        {
            Station station1 = GetById(id);
            station1.GpsWaypoint = station.GpsWaypoint;
            station1.Name = station.Name;
            station1.Street = station.Street;
            station1.City = station.City;
            station1.StationNumber = station.StationNumber;
            station1.Type = station.Type;
            return true;
        }
        public int indexOf(int id)
        {
            return Get().ToList().FindIndex(b => b.Id == id);
        }
    }
}
