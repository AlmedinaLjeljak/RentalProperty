using AutoMapper;
using Rental_Property_Management_Tool.Dtos.RentalProperty;
using Rental_Property_Management_Tool.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Rental_Property_Management_Tool
{
    public class AutoMapperProfile:Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<RentalProperty, GetRentalPropertyDto>();
            CreateMap<AddRentalPropertyDto, RentalProperty>();
        
        }
    }
}
