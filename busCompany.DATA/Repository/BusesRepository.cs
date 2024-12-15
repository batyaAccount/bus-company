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
    public class BusesRepository : IBusesRepository
    {
        readonly DataContext _context;

        public BusesRepository(DataContext context)
        {
            _context = context;
        }
        public IEnumerable<Bus> GetBuses() { return _context.Buses.Include(b => b.SourceStation).Include(b=>b.DestinationStation); }
        public Bus GetByIdBus(int id)
        {

            return _context.Buses.ToList().Find(z => z.BusId == id);

        }
        public bool Add(Bus bus)
        {
            try
            {
               
                _context.Buses.Add(bus);
                _context.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }
        public bool Update(int id, Bus bus)
        {
            //The validate checking was done in the service
            Bus bus1  = _context.Buses.ToList().Find(b => b.BusId == id);

            _ = bus.BusLine != 0 && bus.BusLine != bus1.BusLine ?
            bus1.BusLine = bus.BusLine : bus1.BusLine = bus1.BusLine;

            _ = bus.TravelTime != 0 && bus.TravelTime != bus1.TravelTime ?
            bus1.TravelTime = bus.TravelTime : bus1.TravelTime = bus1.TravelTime;

            _ = bus.IsActive != bus1.IsActive && bus.IsActive!= null?
          bus1.IsActive = bus.IsActive : bus1.IsActive = bus1.IsActive;

            _ = bus.DestinationStationId != 0 && bus.DestinationStationId != bus1.DestinationStationId ?
          bus1.DestinationStationId = bus.DestinationStationId : bus1.DestinationStationId = bus1.DestinationStationId;

            _ = bus.SourceStationId != 0 && bus.SourceStationId != bus1.SourceStationId ?
          bus1.SourceStation = bus.SourceStation : bus1.SourceStation = bus1.SourceStation;

            _ = bus.Type != 0 && bus.Type != bus1.Type ?
        bus1.Type = bus.Type : bus1.Type = bus1.Type;
          _context.SaveChanges();
            return true;
        }
        public bool DeleteBus(int id)
        {
            List<Bus> l = _context.Buses.ToList();

            Bus employeeToDelete = l.FirstOrDefault(e => e.BusId == id);

            if (employeeToDelete != null)
            {
                _context.Buses.Remove(employeeToDelete);
                _context.SaveChanges();
                return true;
            }
            return false;


        }

        public int indexOf(int id)
        {
            return _context.Buses.ToList().FindIndex(b => b.BusId == id);
        }

    }
}
