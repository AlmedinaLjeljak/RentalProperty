using Microsoft.AspNetCore.Mvc;
using Rental_Property_Management_Tool.Data;
using Rental_Property_Management_Tool.Dtos.Person;
using Rental_Property_Management_Tool.Modul1.Models;
using Rental_Property_Management_Tool.Modul1.ViewModel;
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
    public class OpstinaController : ControllerBase
    {
        private readonly DataContext _dbContext;

        public OpstinaController(DataContext dbContext)
        {
            this._dbContext = dbContext;
        }


        [HttpPost]
        public Opstina Add([FromBody] OpstinaAddVM x)
        {
            var newEmployee = new Opstina
            {
                description = x.opis,
                drzava_id = x.drzava_id,
            };

            _dbContext.Add(newEmployee);
            _dbContext.SaveChanges();
            return newEmployee;
        }

       


    }

}
