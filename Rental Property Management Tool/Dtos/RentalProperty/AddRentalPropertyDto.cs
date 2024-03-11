using Rental_Property_Management_Tool.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Rental_Property_Management_Tool.Dtos.RentalProperty
{
    public class AddRentalPropertyDto
    {
        public string Name { get; set; }
        public double SquaresMeters { get; set; }
        public string Address { get; set; }
        public TypesOfRentalProperty Type { get; set; }
    }
}
