using Rental_Property_Management_Tool.Dtos.RentalProperty;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Rental_Property_Management_Tool.Dtos.OverheadCost
{
    public class UpdateOverheadCostDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public double Amount { get; set; }
        public string CostDetails { get; set; }
        public List<GetRentalPropertyDto> RentalProperties { get; set; }
    }
}
