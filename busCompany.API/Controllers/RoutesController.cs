using AutoMapper;
using busCompany.API.PostEntity;
using busCompany.Core.Entity;
using busCompany.CORE.DTOs;
using busCompany.CORE.IRepository;
using busCompany.CORE.IService;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace busCompany.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RoutesController : ControllerBase
    {
        readonly IRoutesService _routesService;
        readonly IMapper _mapper;
        public RoutesController(IRoutesService routesService,IMapper mapper)
        {
            _routesService = routesService;
            _mapper = mapper;
        }
        // GET: api/<RoutesController>
        [HttpGet]
        public IEnumerable<RouteDto> Get()
        {
            return _routesService.GetAll();
        }

        // GET api/<EmployeeController>/5
        [HttpGet("getById/{id}")]
        public ActionResult<RouteDto> GetById(int id)
        {
            if (id < 0)
                return BadRequest();
            var e = _routesService.GetRoute(id);
            if (e == null)
                return NotFound();
            return e;

        }

        // POST api/<EmployeeController>
        [HttpPost]
        public ActionResult<RouteDto> Post([FromBody] RoutePostEntity route)
        {
            var routeD = _mapper.Map<RouteDto>(route);  
            RouteDto b = _routesService.Add(routeD);
            if (b == null)
                return BadRequest();
            return Ok(b);
        }

        // PUT api/<EmployeeController>/5
        [HttpPut("{id}")]
        public ActionResult Put(int id, [FromBody] RoutePostEntity r)
        {
            var routeD = _mapper.Map<RouteDto>(r);

            bool b = _routesService.Update(id, routeD);
            if (b == false)
                return NotFound(false);
            return Ok(b);
        }

        // DELETE api/<EmployeeController>/5
        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            bool b = _routesService.DeleteOne(id);
            if (b == false)
                return NotFound(false);
            return Ok(b);
        }
    }
}
