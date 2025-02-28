﻿using AutoMapper;
using busCompany.API.PostEntity;
using busCompany.Core.Entity;
using busCompany.CORE.DTOs;
using busCompany.CORE.IService;
using Microsoft.AspNetCore.Mvc;
using static System.Collections.Specialized.BitVector32;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace busCompany.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StationsController : ControllerBase
    {
        readonly IStationsService _stationsService;
        readonly IMapper _mapper;
        public StationsController(IStationsService stationsService,IMapper mapper)
        {
            _stationsService = stationsService;
            _mapper = mapper;
        }
        // GET: api/<StationsController>
        [HttpGet]
        public IEnumerable<StationDto> Get()
        {
            return _stationsService.GetAll();
        }

        // GET api/<EmployeeController>/5
        [HttpGet("getById/{id}")]
        public ActionResult<StationDto> GetById(int id)
        {
            if (id < 0)
                return BadRequest();
            var e = _stationsService.GetStation(id);
            if (e == null)
                return NotFound();
            return e;

        }

        // POST api/<EmployeeController>
        [HttpPost]
        public ActionResult<StationDto> Post([FromBody] StationPostEntity station)
        {
            var stationD = _mapper.Map<StationDto>(station);
            StationDto b = _stationsService.Add(stationD);
            if (b == null)
                return BadRequest();
            return Ok(b);
        }

        // PUT api/<EmployeeController>/5
        [HttpPut("{id}")]
        public ActionResult Put(int id, [FromBody] StationPostEntity r)
        {
            var stationD = _mapper.Map<StationDto>(r);

            bool b = _stationsService.Update(id, stationD);
            if (b == false)
                return NotFound(false);
            return Ok(b);
        }

        // DELETE api/<EmployeeController>/5
        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            bool b = _stationsService.DeleteOne(id);
            if (b == false)
                return NotFound(false);
            return Ok(b);
        }
       
    }
}
