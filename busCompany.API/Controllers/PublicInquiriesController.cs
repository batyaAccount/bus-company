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
    public class PublicInquiriesController : ControllerBase
    {
        readonly IPublicInquiriesService _publicInquiriesService;
        readonly IMapper _mapper;
        public PublicInquiriesController(IPublicInquiriesService publicInquiriesService,IMapper mapper)
        {
            _publicInquiriesService = publicInquiriesService;
            _mapper = mapper;
        }
        // GET: api/<PublicInquiriesController>
        [HttpGet]
        public IEnumerable<PublicInquiriesDto> Get()
        {
            return _publicInquiriesService.GetAll();


        }

        // GET api/<BusesController>/5
        [HttpGet("byId/{id}")]
        public ActionResult<PublicInquiriesDto> Get(int id)
        {
            if (id < 0)
                return BadRequest();
            var b = _publicInquiriesService.GetPublicInquiry(id);
            if (b == null)
                return NotFound();
            return b;

        }

        // POST api/<BusesController>
        [HttpPost]
        public ActionResult<PublicInquiriesDto> Post([FromBody] PublicInquiriesPostEntity PublicInquiries)
        {
            var publicInquiriesD = _mapper.Map<PublicInquiriesDto>(PublicInquiries);
            PublicInquiriesDto b = _publicInquiriesService.Add(publicInquiriesD);
            if (b == null)
                return BadRequest();
            return Ok(b);
        }

        // PUT api/<BusesController>/5
        [HttpPut("{id}")]
        public ActionResult Put(int id, [FromBody] PublicInquiriesPostEntity publicInquiry)
        {
            var publicInquiriesD = _mapper.Map<PublicInquiriesDto>(publicInquiry);

            bool b = _publicInquiriesService.Update(id, publicInquiriesD);
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
