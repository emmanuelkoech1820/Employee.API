using Employee.Infrastructure;
using Microsoft.AspNetCore.Mvc;
using System.Data;

namespace Employee.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class SalaryController : ControllerBase
    {        
        private readonly ILogger<SalaryController> _logger;
        private readonly IEmployeeRepository _employeemanager;

        public SalaryController(ILogger<SalaryController> logger, IEmployeeRepository employeemanager)
        {
            _logger = logger;
            _employeemanager = employeemanager;
        }

        
        [HttpPatch]
        public async Task<IActionResult> UpdateSalary(int empID, [FromBody] SalaryUpdateDto salaryUpdateDto)
        {
            var response =  await _employeemanager.UpdateSalary(salaryUpdateDto);
            if(response.Success)
            {
                return BadRequest(response);
            }
            return Ok(response);            
        }
    }

   
}
