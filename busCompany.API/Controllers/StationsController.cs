using busCompany.Core.Entity;
using busCompany.CORE.IService;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace busCompany.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StationsController : ControllerBase
    {
        readonly IStationsService _stationsService;
        public StationsController(IStationsService stationsService)
        {
            _stationsService = stationsService;
        }
        // GET: api/<StationsController>
        [HttpGet]
        public ActionResult<List<Station>> Get()
        {
            return _stationsService.GetAll();
        }

        // GET api/<EmployeeController>/5
        [HttpGet("getById/{id}")]
        public ActionResult<Station> GetById(int id)
        {
            if (id < 0)
                return BadRequest();
            Station e = _stationsService.GetStation(id);
            if (e == null)
                return NotFound();
            return e;

        }

        // POST api/<EmployeeController>
        [HttpPost]
        public ActionResult Post([FromBody] Station station)
        {
            bool b = _stationsService.Add(station);
            if (b == false)
                return NotFound(false);
            return Ok(b);
        }

        // PUT api/<EmployeeController>/5
        [HttpPut("{id}")]
        public ActionResult Put(int id, [FromBody] Station r)
        {
            bool b = _stationsService.Update(id, r);
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
