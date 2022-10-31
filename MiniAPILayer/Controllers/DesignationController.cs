using Microsoft.AspNetCore.Mvc;
using ModelLayer;
using RepositoryLayer;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MiniAPILayer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DesignationController : ControllerBase
    {
        private readonly EmployeeDbContext _dbContext1;
        public DesignationController(EmployeeDbContext dbcontext1)
        {
            _dbContext1 = dbcontext1;
        }



        [HttpPost]
        [Route("designation")]
        public IActionResult Designation([FromBody] Designation designa)
        {
            if (!ModelState.IsValid)
                return BadRequest("not a valid request");
            _dbContext1.DesignationDetails.Add(designa);
            _dbContext1.SaveChanges();
            return Ok();
        }



        [HttpGet]
        [Route("GET")]
        public List<Designation> Get()
        {
            return _dbContext1.DesignationDetails.ToList();

        }
    }
}