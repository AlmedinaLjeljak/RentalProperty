using Microsoft.AspNetCore.Mvc;
using Rental_Property_Management_Tool.Data;
using Rental_Property_Management_Tool.Dtos.Person;
using Rental_Property_Management_Tool.Modul1.Models;
using Rental_Property_Management_Tool.ServiceResponse;
using Rental_Property_Management_Tool.Services.PersonService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Rental_Property_Management_Tool.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class DrzavaController : ControllerBase
    {
        private readonly DataContext _dbContext;

        public DrzavaController(DataContext dbContext)
        {
            this._dbContext = dbContext;
        }

        public class DrzavaAddVM
        {
            public string opis { get; set; }
        }

        [HttpPost]
        public Drzava Add([FromBody] DrzavaAddVM x)
        {
            var newEmployee = new Drzava
            {
                naziv = x.opis,
            };

            _dbContext.Add(newEmployee);
            _dbContext.SaveChanges();
            return newEmployee;
        }

        [HttpGet]
        public object GetAll()
        {
            var data = _dbContext.Drzava
                .OrderBy(s => s.naziv)
                .Select(s => new
                {
                    id = s.id,
                    opis = s.naziv,
                })
                .AsQueryable();
            return data.ToList();
        }
    }

}
