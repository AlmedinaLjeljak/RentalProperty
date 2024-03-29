﻿using Rental_Property_Management_Tool.Dtos.OverheadCost;
using Rental_Property_Management_Tool.Dtos.Person;
using Rental_Property_Management_Tool.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Rental_Property_Management_Tool.Dtos.RentalProperty
{
    public class GetRentalPropertyDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public double SquaresMeters { get; set; }
        public string Address { get; set; }
        public bool Rented { get; set; }
        public TypesOfRentalProperty Type { get; set; }
        public DateTime RentalStart { get; set; }
        public DateTime RentalEnd { get; set; }
        public List<GetOverheadCostDto> Costs { get; set; }
        public GetPersonDto Persons { get; set; }
    }
}
