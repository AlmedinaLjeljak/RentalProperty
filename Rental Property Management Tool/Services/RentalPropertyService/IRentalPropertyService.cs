using Rental_Property_Management_Tool.Dtos.RentalProperty;
using Rental_Property_Management_Tool.ServiceResponse;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Rental_Property_Management_Tool.Services.RentalPropertyService
{
    public interface IRentalPropertyService
    {
        Task<ServiceResponse<List<GetRentalPropertyDto>>> GetAllRentalProperties();
        Task<ServiceResponse<GetRentalPropertyDto>> GetRentalPropertyById(int id);
        Task<ServiceResponse<List<GetRentalPropertyDto>>> AddRentalProperty(AddRentalPropertyDto newRentalProperty);
        Task<ServiceResponse<GetRentalPropertyDto>> UpdateRentalProperty(UpdateRentalPropertyDto updatedRentalProperty);

        Task<ServiceResponse<List<GetRentalPropertyDto>>> DeleteRentalProperty(int id);
    }
}
