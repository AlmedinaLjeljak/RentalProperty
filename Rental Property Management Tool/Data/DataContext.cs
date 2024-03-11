using Microsoft.EntityFrameworkCore;
using Rental_Property_Management_Tool.Entities;
using Rental_Property_Management_Tool.Modul1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Rental_Property_Management_Tool.Data
{
    public class DataContext:DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {

        }
        public DbSet<RentalProperty> RentalProperties { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Person> Persons { get; set; }
        public DbSet<Drzava> Drzava { get; set; }
        public DbSet<Opstina> Opstina { get; set; }
        public DbSet<Employee> Employees { get; set; }


        public DbSet<OverheadCost> OverheadCosts { get; set; }
    }
}
