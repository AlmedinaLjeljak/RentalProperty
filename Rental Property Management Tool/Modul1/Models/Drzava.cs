using System.ComponentModel.DataAnnotations;

namespace Rental_Property_Management_Tool.Modul1.Models
{
    public class Drzava
    {
        [Key]
        public int id { get; set; }
        public string naziv { get; set; }
    }
}
