using busCompany.Core.Entity;
using busCompany.CORE.IService;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace busCompany.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeesController : ControllerBase
    {
        readonly IEmployeesService _employeesService;
        public EmployeesController(IEmployeesService employeesService)
        {
            _employeesService = employeesService;
        }
        // GET: api/<EmployeesController>
        [HttpGet]
        public IEnumerable<Employee> Get()
        {
            return _employeesService.GetAll();


        }

        // GET api/<EmployeeController>/5
        [HttpGet("getById/{id}")]
        public ActionResult<Employee> Get(int id)
        {
            if (id < 0)
                return BadRequest();
            Employee e = _employeesService.GetEmployee(id);
            if (e == null)
                return NotFound();
            return e;

        }

        // POST api/<EmployeeController>
        [HttpPost]
        public ActionResult Post([FromBody] Employee employee)
        {
            bool b = _employeesService.Add(employee);
            if (b == false)
                return BadRequest();
            return Ok(true);
        }

        // PUT api/<EmployeeController>/5
        [HttpPut("{id}")]
        public ActionResult Put(int id, [FromBody] Employee employee)
        {
            bool b = _employeesService.Update(id, employee);
            if (b == false)
                return NotFound(false);
            return Ok(true);
        }

        // DELETE api/<EmployeeController>/5
        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            bool b = _employeesService.DeleteOne(id);
            if (b == false)
                return NotFound(false);
            return Ok(true);
        }
    }
}
