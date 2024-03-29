﻿using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Rental_Property_Management_Tool.Modul1.Models
{
    public class Opstina
    {
        [Key]
        public int id { get; set; }
        public string description { get; set; }
        [ForeignKey(nameof(drzava))]
        public int drzava_id { get; set; }
        public Drzava drzava { get; set; }
    }
}
