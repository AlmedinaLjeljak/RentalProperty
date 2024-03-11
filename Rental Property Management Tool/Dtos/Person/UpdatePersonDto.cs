using Rental_Property_Management_Tool.Dtos.RentalProperty;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Rental_Property_Management_Tool.Dtos.Person
{
    public class UpdatePersonDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Contact { get; set; }
        public bool LegalEntity { get; set; }
        public List<GetRentalPropertyDto> RentedProperties { get; set; }
    }
}
