﻿using Microsoft.AspNetCore.Mvc;
using Rental_Property_Management_Tool.Dtos.OverheadCost;
using Rental_Property_Management_Tool.ServiceResponse;
using Rental_Property_Management_Tool.Services.OverheadCostService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Rental_Property_Management_Tool.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class OverheadCostController : ControllerBase
    {
        private readonly IOverheadCostService _overheadCostService;
        public OverheadCostController(IOverheadCostService overheadCostService)
        {
            _overheadCostService = overheadCostService;
        }
        [HttpGet("GetAll")]
        public async Task<ActionResult<ServiceResponse<List<GetOverheadCostDto>>>> Get()
        {
            return Ok(await _overheadCostService.GetAllOverheadCosts());
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<ServiceResponse<GetOverheadCostDto>>> GetSingle(int id)
        {
            return Ok(await _overheadCostService.GetOverheadCostById(id));
        }

        [HttpPost]
        public async Task<ActionResult<ServiceResponse<List<GetOverheadCostDto>>>> AddOverheadCost(AddOverheadCostDto newOverheadCost)
        {
            return Ok(await _overheadCostService.AddOverheadCost(newOverheadCost));
        }
        [HttpPut]
        public async Task<ActionResult<ServiceResponse<GetOverheadCostDto>>> UpdateOverheadCost(UpdateOverheadCostDto updatedOverheadCost)
        {
            var response = await _overheadCostService.UpdateOverheadCost(updatedOverheadCost);
            if (response.Data == null)
            {
                return NotFound(response);
            }
            return Ok(response);
        }
        [HttpDelete("{id}")]
        public async Task<ActionResult<ServiceResponse<GetOverheadCostDto>>> Delete(int id)
        {
            var response = await _overheadCostService.DeleteOverheadCost(id);
            if (response.Data == null)
            {
                return NotFound(response);
            }
            return Ok(response);
        }
    }
}
