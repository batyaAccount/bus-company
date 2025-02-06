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
    public class RoutesRepository:Repository<Route>, IRouteRepository
    {
        readonly DataContext _context;
        public RoutesRepository(DataContext context):base(context)
        {
            _context = context;
        }
        public override IEnumerable<Route> Get() { return _dbSet.Include(p => p.Driver).Include(p=>p.Station); }
        public bool Update(int id, Route route)
        {

            Route route1 = GetById(id);
            route1.SourceStationId = route.SourceStationId;
            route1.StationId = route.StationId;
            route1.BusLineId = route.BusLineId;
            route1.HourOfFirstBus = route.HourOfFirstBus;
            route1.HourOfLastBus = route.HourOfLastBus;
            route1.Driver = route.Driver;
            return true;
        }

        public int indexOf(int id)
        {
            return Get().ToList().FindIndex(b => b.Id == id);
        }
    }
}
