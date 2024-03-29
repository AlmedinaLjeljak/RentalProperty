﻿using AutoMapper;
using Rental_Property_Management_Tool.Data;
using Rental_Property_Management_Tool.Dtos.RentalProperty;
using Rental_Property_Management_Tool.ServiceResponse;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Rental_Property_Management_Tool.Services.RentalPropertyService
{
    
        public class RentalPropertyService : IRentalPropertyService
        {
            private readonly IMapper _mapper;
            private readonly DataContext _context;
            public RentalPropertyService(IMapper mapper, DataContext context)
            {
                _mapper = mapper;
                _context = context;
            }
            public Task<ServiceResponse<List<GetRentalPropertyDto>>> GetAllRentalProperties()
            {
                throw new System.NotImplementedException();
            }

            public Task<ServiceResponse<GetRentalPropertyDto>> GetRentalPropertyById(int id)
            {
                throw new System.NotImplementedException();
            }

            public Task<ServiceResponse<List<GetRentalPropertyDto>>> AddRentalProperty(AddRentalPropertyDto newRentalProperty)
            {
                throw new System.NotImplementedException();

            }
            public Task<ServiceResponse<GetRentalPropertyDto>> UpdateRentalProperty(UpdateRentalPropertyDto updatedRentalProperty)
            {
                throw new System.NotImplementedException();
            }

            public Task<ServiceResponse<List<GetRentalPropertyDto>>> DeleteRentalProperty(int id)
            {
                throw new System.NotImplementedException();
            }
        }
}
