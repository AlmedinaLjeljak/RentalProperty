using System;

namespace Rental_Property_Management_Tool.Modul1.ViewModel
{
    public class EmployeeGetAllVM
    {
        public int id { get; set; }
        public string employee_name { get; set; }
        public float? employee_salary { get; set; }
        public int? employee_age { get; set; }
        public DateTime created_time { get; set; }
        public string profile_image { get; set; }
        public int task_count { get; set; }
    }
}
