using AutoMapper;
using busCompany.API.PostEntity;
using busCompany.Core.Entity;
using busCompany.CORE.DTOs;
using busCompany.CORE.IService;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace busCompany.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BusesController : ControllerBase
    {
        readonly IBusesService _busesService;
        readonly IMapper _mapper;
        public BusesController(IBusesService busesService,IMapper mapper)
        {
            _busesService = busesService;
            _mapper = mapper;
        }
        // GET: api/<BusesController>
        [HttpGet]
        public IEnumerable<BusDto> Get()
        {
            return _busesService.GetAll();
        }

        // GET api/<BusesController>/5
        [HttpGet("byId/{id}")]
        public ActionResult<BusDto> Get(int id)
        {
            if (id < 0)
                return BadRequest();
            var b = _busesService.GetBus(id);
            if (b == null)
                return NotFound();
            return b;

        }

        // POST api/<BusesController>
        [HttpPost]
        public ActionResult<BusDto> Post([FromBody] BusesPostEntity bus)
        {
            var busD =_mapper.Map<BusDto>(bus);
            BusDto b = _busesService.Add(busD);
            if (b == null)
                return BadRequest();
            return Ok(b);
        }

        // PUT api/<BusesController>/5
        [HttpPut("{id}")]
        public ActionResult Put(int id, [FromBody] BusesPostEntity bus)
        {
            var busD = _mapper.Map<BusDto>(bus);
            bool b = _busesService.Update(id, busD);
            if (b == false)
                return NotFound(false);
            return Ok(b);
        }

        // DELETE api/<BusesController>/5
        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            bool b = _busesService.DeleteOne(id);
            if (b == false)
                return NotFound(false);
            return Ok(b);
        }
    }
}
