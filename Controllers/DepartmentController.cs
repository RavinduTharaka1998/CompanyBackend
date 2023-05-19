﻿using CompanyBackend.Models;
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
        public async Task<ActionResult<IEnumerable<Department>>> GetDepartments()
        {
            if (_departmentContext.Department == null)
            {
                return NotFound();
            }

            return await _departmentContext.Department.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Department>> GetDepartment(int id)
        {
            if (_departmentContext.Department == null)
            {
                return NotFound();
            }

            var department = await _departmentContext.Department.FindAsync(id);
            if (department == null)
            {
                return NotFound();
            }
            return department;
        }

        [HttpPost]
        public async Task<ActionResult<Department>> PostDepartment(Department department)
        {

            _departmentContext.Department.Add(department);
            await _departmentContext.SaveChangesAsync();

            return CreatedAtAction(nameof(GetDepartment), new { id = department.Id }, department);
        }


        [HttpPut("{id}")]
        public async Task<ActionResult> PutDepartment(int id, Department department)
        {
            if (id != department.Id)
            {
                return BadRequest();
            }

            _departmentContext.Entry(department).State = EntityState.Modified;
            try
            {
                await _departmentContext.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                throw;
            }
            return Ok();

        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteDepartment(int id)
        {
            if (_departmentContext.Department == null)
            {
                return NotFound();
            }

            var department = await _departmentContext.Department.FindAsync(id);
            if (department == null)
            {
                return NotFound();
            }

            _departmentContext.Department.Remove(department);
            await _departmentContext.SaveChangesAsync();

            return Ok();
        }


    }
}
