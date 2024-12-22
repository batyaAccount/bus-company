using busCompany.Core.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace busCompany.CORE.IRepository
{
    public interface IRepositoryMamager
    {

        IBusesRepository Buses { get; }
        IEmployeeRepository Employees { get; }
        IPublicInquiriesRepository PublicInquiries { get; }
        IRouteRepository Routes { get; }
        IStationRepository Stations { get; }

        void Save();

    }
}
