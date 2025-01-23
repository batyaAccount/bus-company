using busCompany.Core.Entity;
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
        public BusesController(IBusesService busesService)
        {
            _busesService = busesService;
        }
        // GET: api/<BusesController>
        [HttpGet]
        public IEnumerable<Bus> Get()
        {
            return _busesService.GetAll();
        }

        // GET api/<BusesController>/5
        [HttpGet("byId/{id}")]
        public ActionResult<Bus> Get(int id)

        {
            if (id < 0)
                return BadRequest();
            Bus b = _busesService.GetBus(id);
            if (b == null)
                return NotFound();
            return b;

        }

        // POST api/<BusesController>
        [HttpPost]
        public ActionResult<Bus> Post([FromBody] Bus bus)
        {
            Bus b = _busesService.Add(bus);
            if (b == null)
                return BadRequest();
            return Ok(b);
        }

        // PUT api/<BusesController>/5
        [HttpPut("{id}")]
        public ActionResult Put(int id, [FromBody] Bus bus)
        {
            bool b = _busesService.Update(id, bus);
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
