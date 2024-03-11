using Newtonsoft.Json.Converters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Rental_Property_Management_Tool.Enum
{
    [JsonConverter(typeof(StringEnumConverter))]
    public enum TypesOfRentalProperty
    {
        House,
        Garage,
        Apartment
    }
}
