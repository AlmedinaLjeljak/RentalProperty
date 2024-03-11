using Rental_Property_Management_Tool.Dtos.OverheadCost;
using Rental_Property_Management_Tool.ServiceResponse;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Rental_Property_Management_Tool.Services.OverheadCostService
{
    public interface IOverheadCostService
    {
        Task<ServiceResponse<List<GetOverheadCostDto>>> GetAllOverheadCosts();
        Task<ServiceResponse<GetOverheadCostDto>> GetOverheadCostById(int id);
        Task<ServiceResponse<List<GetOverheadCostDto>>> AddOverheadCost(AddOverheadCostDto newOverheadCost);
        Task<ServiceResponse<GetOverheadCostDto>> UpdateOverheadCost(UpdateOverheadCostDto updatedOverheadCost);
        Task<ServiceResponse<List<GetOverheadCostDto>>> DeleteOverheadCost(int id);
    }
}
