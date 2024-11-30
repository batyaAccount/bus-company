using busCompany.Core.Entity;
using busCompany.CORE.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace busCompany.DATA.Repository
{
    public class BusesRepository:IBusesRepository
    {
        readonly DataContext _context;
        public BusesRepository(DataContext context)
        {
            _context = context;
        }
        public List<Bus> GetBuses() { return _context.Buses; }
        public Bus GetByIdBus(int id)
        {

            return _context.Buses.Find(z => z.Id == id);

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
            Bus bus1 = _context.Buses.Find(b => b.Id == id);
            if (bus1 == null)
                return false;
            DeleteBus(id);
            bus1.Id = id;
            bus1.BusLine = bus.BusLine;
            bus1.SourceStation = bus.SourceStation;
            bus1.DestinationStation = bus.DestinationStation;
            bus1.IsActive = bus.IsActive;
            bus1.Type = bus.Type;
            bus1.TravelTime = bus.TravelTime;
            if (Add(bus1))
                return true;
            return false;
        }
        public bool DeleteBus(int id)
        {
            List<Bus> l = _context.Buses;

            Bus employeeToDelete = l.FirstOrDefault(e => e.Id == id);

            if (employeeToDelete != null)
            {
                _context.Buses.Remove(employeeToDelete);
                _context.SaveChanges();
                return true;
            }

            return false;

        }
    }
}
