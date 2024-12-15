using busCompany.Core.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace busCompany.CORE.IRepository
{
    public interface IRouteRepository
    {
        public IEnumerable<Route> GetRoutes();
        public Route GetByIdRoute(int id);
        public bool Add(Route route);
        public bool Update(int id, Route route);
        public bool DeleteRoute(int id);
        public int indexOf(int id);

    }
}
