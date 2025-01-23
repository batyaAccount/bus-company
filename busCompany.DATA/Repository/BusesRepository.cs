using busCompany.Core.Entity;
using busCompany.CORE.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
namespace busCompany.DATA.Repository
{
    public class BusesRepository : Repository<Bus>, IBusesRepository
    {
        public BusesRepository(DataContext context) : base(context)
        {
        }
        public override IEnumerable<Bus> Get() { return _dbSet.Include(b => b.SourceStation).Include(b => b.DestinationStation); }
        public bool Update(int id, Bus bus)
        {

            Bus bus1 = GetById(id);
            bus1.BusLine = bus.BusLine;
            bus1.TravelTime = bus.TravelTime;
            bus1.IsActive = bus.IsActive;
            bus1.DestinationStationId = bus.DestinationStationId;
            bus1.SourceStationId = bus.SourceStationId;
            bus1.Type = bus.Type;
            return true;
        }
        public int indexOf(int id)
        {
            return Get().ToList().FindIndex(b => b.BusId == id);
        }

    }
}
