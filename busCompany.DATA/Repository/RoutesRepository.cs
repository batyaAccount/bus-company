using busCompany.Core.Entity;
using busCompany.CORE.IRepository;
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
        public List<Route> GetRoutes() { return _context.Routes; }
        public Route GetByIdRoute(int id)
        {

            return _context.Routes.Find(z => z.Id == id);

        }
        public bool Add(Route route)
        {
          
            try
            {
                _context.Routes.Add(route);
                _context.SaveChanges();
               
                return true;
            }
            catch
            {
                return false;

            }

        }
        public bool Update(int id, Route route)
        {
            Route r = _context.Routes.Find(b => b.Id == id);
            if (r == null)
                return false;
            DeleteRoute(id);
            r.Station = route.Station;
            r.HourOfLastBus = route.HourOfLastBus;
            r.BusLineId = route.BusLineId;
            r.HourOfFirstBus = route.HourOfFirstBus;
            r.SourceStationId = route.SourceStationId;
            r.Driver = route.Driver;
            r.Id = id;
            if (Add(r))
                return true;
            return false;
        }
        public bool DeleteRoute(int id)
        {
            List<Route> l = _context.Routes;

            Route publicToDelete = l.FirstOrDefault(e => e.Id == id);

            if (publicToDelete != null)
            {
                _context.Routes.Remove(publicToDelete);
                _context.SaveChanges();
                return true;
            }

            return false;

        }
    }
}
