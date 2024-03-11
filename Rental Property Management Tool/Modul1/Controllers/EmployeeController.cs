using Microsoft.AspNetCore.Mvc;
using Rental_Property_Management_Tool.Data;
using Rental_Property_Management_Tool.Dtos.Person;
using Rental_Property_Management_Tool.Modul1.Models;
using Rental_Property_Management_Tool.Modul1.ViewModel;
using Rental_Property_Management_Tool.ServiceResponse;
using Rental_Property_Management_Tool.Services.PersonService;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Rental_Property_Management_Tool.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class EmployeeController : ControllerBase
    {
        private readonly DataContext _dbContext;

        public EmployeeController(DataContext dbContext)
        {
            this._dbContext = dbContext;
        }

        [HttpGet("{id}")]
        public Employee Get(int id)
        {
            return _dbContext.Employees.Find(id);
        }

       
        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            if (_dbContext.Employees.Count() < 100)
                return BadRequest("ne moze se obrisati ako je broj zapisa manji od 100");

            Employee employee = _dbContext.Employees.Find(id);

            if (employee == null || id == 1)
                return BadRequest("pogresan ID");

            _dbContext.Remove(employee);

            _dbContext.SaveChanges();
            return Ok(employee);
        }
        

    }

}
