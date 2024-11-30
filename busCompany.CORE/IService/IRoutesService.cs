using busCompany.Core.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace busCompany.CORE.IService
{
    public interface IRoutesService
    {
        public List<Route> GetAll();
        public Route GetRoute(int id);
        public bool Add(Route route);
        public bool Update(int id, Route route);
        public bool DeleteOne(int id);
    }
}
