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
        public List<Station> GetStations();
        public Station getByIdStation(int id);
        public bool Add(Station station);
        public bool Update(int id, Station station);
        public bool DeleteStation(int id);
    }
}
