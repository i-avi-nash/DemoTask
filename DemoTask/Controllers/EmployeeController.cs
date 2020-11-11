using DemoTask.Data;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace DemoTask.Controllers
{
    [Route("/api/employee")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly EmployeeContext _context;

        public EmployeeController(EmployeeContext context)
        {
            _context = context;
        }

        // GET api/employee
        [HttpGet]
        public ActionResult<IEnumerable<Employee>> GetAllEmployees()
        {
            return _context.Employees.ToList();
        }

        // GET api/employee/{id}
        [HttpGet("{id}", Name = "GetEmployeeById")]
        public ActionResult<Employee> GetEmployeeById(int id)
        {
            var employee = _context.Employees.FirstOrDefault(e => e.Id == id);
            if (employee != null)
            {
                return Ok(employee);
            }
            return NotFound();
        }

        // POST api/employee
        [HttpPost]
        public ActionResult<Employee> CreateEmployee(Employee employee)
        {
            _context.Employees.Add(employee);
            _context.SaveChanges();

            return Ok(employee);
        }

        // PUT api/employee/{id}
        [HttpPut("{id}")]
        public ActionResult UpdateEmployee(int id, Employee employee)
        {
            var updatedEmployee = _context.Employees.FirstOrDefault(e => e.Id == id);
            if (updatedEmployee == null)
            {
                return NotFound();
            }

            updatedEmployee.Name = employee.Name;
            updatedEmployee.Age = employee.Age;
            updatedEmployee.Address = employee.Address;

            _context.Employees.Update(updatedEmployee);
            _context.SaveChanges();
            return NoContent();
        }

        // DELETE api/employee/{id}
        [HttpDelete("{id}")]
        public ActionResult DeleteEmployee(int id)
        {
            var employee = _context.Employees.FirstOrDefault(e => e.Id == id);
            if (employee == null)
            {
                return NotFound();
            }

            _context.Employees.Remove(employee);
            _context.SaveChanges();

            return NoContent();
        }
    }
}
