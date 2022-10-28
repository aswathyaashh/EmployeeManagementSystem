using BusinessLogicLayer.Interface;
using Microsoft.AspNetCore.Mvc;
using ModelLayer;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MiniAPILayer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {

        private readonly IEmployee _employee;
        public EmployeeController(IEmployee employee)
        {
            _employee = employee;
        }
        [HttpGet]
        [Route("get")]
      //  [Authorize]
        public ActionResult<List<EmployeeDetails>> Get()
        {
            return _employee.Get();
        }
        [HttpGet]
        [Route("get/{username}")]
        public ActionResult<EmployeeDetails> Get(string username)
        {
            return _employee.Get(username);
        }
        [HttpPost("post")]
        public IActionResult Post([FromBody] EmployeeDetails emp)
        {
            if (!ModelState.IsValid)
                return BadRequest("Is not valid");
            _employee.Post(emp);
            return Ok();
        }
        [HttpDelete]
        [Route("delete/{UserName}")]
        public ActionResult Delete(string UserName)
        {
            _employee.Delete(UserName);
            return Ok();
        }
        [HttpPost]
        [Route("Edit")]
        public IActionResult Edit([FromBody] EmployeeDetails emp)
        {
            if (!ModelState.IsValid)
                return BadRequest("Is not valid");
            _employee.Edit(emp);
            return Ok();
        }
    }
}
