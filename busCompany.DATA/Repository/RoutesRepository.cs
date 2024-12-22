using busCompany.Core.Entity;
using busCompany.CORE.IRepository;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace busCompany.DATA.Repository
{
    public class RoutesRepository:IRouteRepository
    {
        readonly DataContext _context;
        public RoutesRepository(DataContext context)
        {
            _context = context;
        }
        public IEnumerable<Route> GetRoutes() { return _context.Routes.Include(p => p.Driver).Include(p=>p.Station); }
        public Route GetByIdRoute(int id)
        {

            return _context.Routes.ToList().Find(z => z.Id == id);

        }
        public bool Add(Route route)
        {
          
            try
            {
                _context.Routes.Add(route);
                return true;
            }
            catch
            {
                return false;

            }

        }
        public bool Update(int id, Route route)
        {

            //The validate checking was done in the service
            Route route1 = _context.Routes.ToList().Find(b => b.Id == id);

            _ = route.SourceStationId != route1.SourceStationId && route.SourceStationId != 0 ?
              route1.SourceStationId = route.SourceStationId : route1.SourceStationId = route1.SourceStationId;

            _ = route.StationId != route1.StationId && route.StationId != 0 ?
              route1.Station = route.Station : route1.Station = route1.Station;

            _ = route.BusLineId != route1.BusLineId && route.BusLineId != 0 ?
              route1.BusLineId = route.BusLineId : route1.BusLineId = route1.BusLineId;

            _ = route.HourOfFirstBus != route1.HourOfFirstBus && route.HourOfFirstBus != DateTime.MinValue ?
              route1.HourOfFirstBus = route.HourOfFirstBus : route1.HourOfFirstBus = route1.HourOfFirstBus;

            _ = route.HourOfLastBus != route1.HourOfLastBus && route.HourOfLastBus != DateTime.MinValue ?
              route1.HourOfLastBus = route.HourOfLastBus : route1.HourOfLastBus = route1.HourOfLastBus;

            _ = route.DriverId != route1.DriverId && route.DriverId != 0 ?
              route1.Driver = route.Driver : route1.Driver = route1.Driver;
            return true;
        }
        public bool DeleteRoute(int id)
        {
            List<Route> l = _context.Routes.ToList();

            Route publicToDelete = l.FirstOrDefault(e => e.Id == id);

            if (publicToDelete != null)
            {
                _context.Routes.Remove(publicToDelete);
                return true;
            }

            return false;

        }

        public int indexOf(int id)
        {
            return _context.Routes.ToList().FindIndex(b => b.Id == id);
        }
    }
}
