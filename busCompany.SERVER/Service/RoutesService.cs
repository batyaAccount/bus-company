﻿using AutoMapper;
using busCompany.Core.Entity;
using busCompany.CORE.DTOs;
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
        readonly IRepositoryMamager _repositoryMamager;
        readonly IRouteRepository _routeRepository;
        readonly IMapper _mapper;
        public RoutesService(IRepositoryMamager repositoryMamager, IRouteRepository routeRepository,IMapper mapper)
        {
            _repositoryMamager = repositoryMamager;
            _routeRepository = routeRepository;
            _mapper = mapper;
        }
        public Route Add(Route route)
        {
            if (GetRoute(route.Id) != null)
                return null;
            _routeRepository.Add(route);
            _repositoryMamager.Save();
            return route;
        }

        public bool DeleteOne(int id)
        {
            if(_routeRepository.indexOf(id) == -1) 
                return false;    
             _routeRepository.Delete(id);
              _repositoryMamager.Save();
            return true;
        }

        public IEnumerable<RouteDto> GetAll()
        {
            var routes =  _routeRepository.Get().ToList();
            return _mapper.Map<IEnumerable<RouteDto>>(routes);
        }

        public RouteDto GetRoute(int id)
        {
            var route = _routeRepository.GetById(id);
            return _mapper.Map<RouteDto>(route);
        }

        public bool Update(int id, Route route)
        {
            if (GetAll().Count() == 0)
                return false;
            if (_routeRepository.indexOf(id) == -1)
                return false;
            bool flag = _routeRepository.Update(id, route);
            if (flag)
                _repositoryMamager.Save();
            return flag;
        }
    }
}
