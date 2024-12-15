using busCompany.Core.Entity;
using busCompany.CORE.IRepository;
using busCompany.CORE.IService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace busCompany.SERVICE.Service
{
    public class RoutesService : IRoutesService
    {
        readonly IRouteRepository _routeRepository;
        public RoutesService(IRouteRepository routeRepository)
        {
            _routeRepository = routeRepository;
        }
        public bool Add(Route route)
        {
            if (GetRoute(route.Id) != null)
                return false;
            return _routeRepository.Add(route);
        }

        public bool DeleteOne(int id)
        {
            return _routeRepository.DeleteRoute(id);
        }

        public IEnumerable<Route> GetAll()
        {
            return _routeRepository.GetRoutes();
        }

        public Route GetRoute(int id)
        {
            return _routeRepository.GetByIdRoute(id);
        }

        public bool Update(int id, Route route)
        {
            if (GetAll().Count() == 0)
                return false;
            if (_routeRepository.indexOf(id) == -1)
                return false;
            return _routeRepository.Update(id, route);       
        }
    }
}
