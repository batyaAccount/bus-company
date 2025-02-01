using AutoMapper;
using busCompany.Core.Entity;
using busCompany.CORE.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace busCompany.CORE
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Bus,BusDto>().ReverseMap();
            CreateMap<Employee,EmployeeDto>().ReverseMap();
            CreateMap<PublicInquiries,PublicInquiriesDto>().ReverseMap();
            CreateMap<Station,StationDto>().ReverseMap();
            CreateMap<Route,RouteDto>().ReverseMap();

        }
    }
}
