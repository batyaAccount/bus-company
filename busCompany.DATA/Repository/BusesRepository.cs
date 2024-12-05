using busCompany.Core.Entity;
using busCompany.CORE.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace busCompany.DATA.Repository
{
    public class BusesRepository : IBusesRepository
    {
        readonly DataContext _context;

        public BusesRepository(DataContext context)
        {
            _context = context;
        }
        public List<Bus> GetBuses() { return _context.Buses.ToList(); }
        public Bus GetByIdBus(int id)
        {

            return _context.Buses.ToList().Find(z => z.Id == id);

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
            Bus bus1  = _context.Buses.ToList().Find(b => b.Id == id);

            _ = bus.BusLine != 0 && bus.BusLine != bus1.BusLine ?
            bus1.BusLine = bus.BusLine : bus1.BusLine = bus1.BusLine;

            _ = bus.TravelTime != 0 && bus.TravelTime != bus1.TravelTime ?
            bus1.TravelTime = bus.TravelTime : bus1.TravelTime = bus1.TravelTime;

            _ = bus.IsActive != bus1.IsActive ?
          bus1.IsActive = bus.IsActive : bus1.IsActive = bus1.IsActive;

            _ = bus.DestinationStation != null && bus.DestinationStation != bus1.DestinationStation ?
          bus1.DestinationStation = bus.DestinationStation : bus1.DestinationStation = bus1.DestinationStation;

            _ = bus.SourceStation != null && bus.SourceStation != bus1.SourceStation ?
          bus1.SourceStation = bus.SourceStation : bus1.SourceStation = bus1.SourceStation;

            _ = bus.Type != null && bus.Type != bus1.Type ?
        bus1.Type = bus.Type : bus1.Type = bus1.Type;
          _context.SaveChanges();
            return true;
        }
        public bool DeleteBus(int id)
        {
            List<Bus> l = _context.Buses.ToList();

            Bus employeeToDelete = l.FirstOrDefault(e => e.Id == id);

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
            return _context.Buses.ToList().FindIndex(b => b.Id == id);
        }

    }
}
