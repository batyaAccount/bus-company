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
        readonly IRepositoryMamager _routeRepository;
        public RoutesService(IRepositoryMamager routeRepository)
        {
            _routeRepository = routeRepository;
        }
        public bool Add(Route route)
        {
            if (GetRoute(route.Id) != null)
                return false;
            bool flag = _routeRepository.Routes.Add(route);
            if (flag)
                _routeRepository.Save();
            return flag;
        }

        public bool DeleteOne(int id)
        {
            bool flag = _routeRepository.Routes.DeleteRoute(id);
            if (flag)
                _routeRepository.Save();
            return flag;
        }

        public IEnumerable<Route> GetAll()
        {
            return _routeRepository.Routes.GetRoutes();
        }

        public Route GetRoute(int id)
        {
            return _routeRepository.Routes.GetByIdRoute(id);
        }

        public bool Update(int id, Route route)
        {
            if (GetAll().Count() == 0)
                return false;
            if (_routeRepository.Routes.indexOf(id) == -1)
                return false;
            bool flag = _routeRepository.Routes.Update(id, route);
            if (flag)
                _routeRepository.Save();
            return flag;
        }
    }
}
