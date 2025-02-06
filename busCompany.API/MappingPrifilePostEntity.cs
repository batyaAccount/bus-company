using AutoMapper;
using busCompany.CORE.DTOs;
using busCompany.Core.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using busCompany.API.PostEntity;

namespace busCompany.CORE
{
    internal class MappingPrifilePostEntity:Profile
    {
        public MappingPrifilePostEntity()
        {
            CreateMap<BusesPostEntity,BusDto>().ReverseMap();
            CreateMap< EmployeePostEntity,EmployeeDto>().ReverseMap();
            CreateMap< StationPostEntity,StationDto>().ReverseMap();
            CreateMap<RoutePostEntity,RouteDto>().ReverseMap();
            CreateMap< PublicInquiriesPostEntity,PublicInquiriesDto>().ReverseMap();

        }
    }
}
