using CompanyBackend.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CompanyBackend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DepartmentController : ControllerBase
    {
        private readonly CompanyContext _departmentContext;

        public DepartmentController(CompanyContext departmentContext)
        {
            _departmentContext = departmentContext;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Department>>> GetDepartment()
        {
            if (_departmentContext.Department == null)
            {
                return NotFound();
            }

            return await _departmentContext.Department.ToListAsync();
        }

        [HttpPost]
        public async Task<ActionResult<Department>> PostDepartment(Department department)
        {

            _departmentContext.Department.Add(department);
            await _departmentContext.SaveChangesAsync();

            return CreatedAtAction(nameof(GetDepartment), new { id = department.Id }, department);
        }
    }
}
