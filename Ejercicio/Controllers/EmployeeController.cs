using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Ejercicio.Context;
using Ejercicio.Models;

namespace Ejercicio.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly AppDbContext _context;

        public EmployeeController(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/Employee
        [HttpGet]

        public IActionResult GetEmployee()
        {
            var employee = _context.Employees.Include(e => e.Role).ToList();
            var formattedEmployee = employee.Select(e => new
            {
                id = e.Id,
                name = e.Name,
                photo = e.Photo,
                document = e.Document,
                date = e.dateIn.ToString("yyyy-MM-dd"),
                idRole = e.IdRole,
                roles = e.Role
            });

            return Ok(formattedEmployee);
        }
        // GET: api/Employee/5
        [HttpGet("{id}")]

        public IActionResult GetEmployeeById(int id)
        {
            var employee = _context.Employees.Include(e => e.Role).FirstOrDefault(e => e.Id == id);

            if (employee == null)
            {
                return NotFound();
            }

            var formattedEmployee = (new
            {
                id = employee.Id,
                name = employee.Name,
                photo = employee.Photo,
                document = employee.Document,
                date = employee.dateIn.ToString("yyyy-MM-dd"),
                idRole = employee.IdRole,
                roles = employee.Role
            });

            return Ok(formattedEmployee);
        }
        // PUT: api/Employee/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]

        public IActionResult UpdateEmployee(int id, [FromBody] Employee employee)
        {
            var employeeU = _context.Employees.Find(id);
            if (employeeU == null)
            {
                return NotFound();
            }

            employeeU.Name = employee.Name;
            employeeU.Photo = employee.Photo;
            employeeU.Document = employee.Document;
            employeeU.IdRole = employee.IdRole;
            employeeU.dateIn = employeeU.dateIn;

            _context.SaveChanges();
            return NoContent();

        }

        // POST: api/Employee
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public IActionResult CreateEmployee([FromBody] Employee employee)
        {
            _context.Employees.Add(employee);
            _context.SaveChanges();
            return CreatedAtAction(nameof(GetEmployeeById), new { id = employee.Id }, employee);
        }

        // DELETE: api/Employee/5
        [HttpDelete("{id}")]
        public IActionResult DeleteEmployee(int id) {

            var employee = _context.Employees.Find(id);
            if (employee == null) { 
                return NotFound();
            }
            _context.Employees.Remove(employee);
            _context.SaveChanges();
            return NoContent();
        }

        private bool EmployeeExists(int id)
        {
            return _context.Employees.Any(e => e.Id == id);
        }
    }
}
