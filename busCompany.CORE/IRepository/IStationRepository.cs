using busCompany.Core.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace busCompany.CORE.IRepository
{
    public interface IStationRepository
    {
        public IEnumerable<Station> Get();
        public Station GetById(int id);
        public Station Add(Station station);
        public bool Update(int id, Station station);
        public void Delete(int id);
        public int indexOf(int id);

    }
}
