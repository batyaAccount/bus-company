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
        public IEnumerable<Route> Get();
        public Route GetById(int id);
        public Route Add(Route route);
        public bool Update(int id, Route route);
        public void Delete(int id);
        public int indexOf(int id);

    }
}
