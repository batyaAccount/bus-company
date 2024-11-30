using busCompany.Core.Entity;
using busCompany.CORE.IService;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace busCompany.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PublicInquiriesController : ControllerBase
    {
        readonly IPublicInquiriesService _publicInquiriesService;
        public PublicInquiriesController(IPublicInquiriesService publicInquiriesService)
        {
            _publicInquiriesService = publicInquiriesService;
        }
        // GET: api/<PublicInquiriesController>
        [HttpGet]
        public ActionResult<List<PublicInquiries>> Get()
        {
            return _publicInquiriesService.GetAll();


        }

        // GET api/<BusesController>/5
        [HttpGet("byId/{id}")]
        public ActionResult<PublicInquiries> Get(int id)
        {
            if (id < 0)
                return BadRequest();
            PublicInquiries b = _publicInquiriesService.GetPublicInquiry(id);
            if (b == null)
                return NotFound();
            return b;

        }

        // POST api/<BusesController>
        [HttpPost]
        public ActionResult Post([FromBody] PublicInquiries bus)
        {
            bool b = _publicInquiriesService.Add(bus);
            if (b == false)
                return BadRequest();
            return Ok(b);
        }

        // PUT api/<BusesController>/5
        [HttpPut("{id}")]
        public ActionResult Put(int id, [FromBody] PublicInquiries publicInquiry)
        {
            bool b = _publicInquiriesService.Update(id, publicInquiry);
            if (b == false)
                return NotFound(false);
            return Ok(b);
        }

        // DELETE api/<BusesController>/5
        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            bool b = _publicInquiriesService.DeleteOne(id);
            if (b == false)
                return NotFound(false);
            return Ok(b);
        }
    }
}
