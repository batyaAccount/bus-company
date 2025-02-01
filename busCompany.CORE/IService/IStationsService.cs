using busCompany.Core.Entity;
using busCompany.CORE.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace busCompany.CORE.IService
{
    public interface IStationsService
    {
        public IEnumerable<StationDto> GetAll();
        public StationDto GetStation(int id);
        public Station Add(Station station);
        public bool Update(int id, Station station);
        public bool DeleteOne(int id);
    }
}
