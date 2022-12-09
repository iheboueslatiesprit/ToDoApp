using System.ComponentModel.DataAnnotations;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace ToDoApp.Models
{
    [Table("Employee")]
    public class Employee
    {
        [Key]
        public int EmployeeID { get; set; }
        public string EmployeeName { get; set; }
        public string TodoItem { get; set; }
        public string EmailId { get; set; }
        public DateTime DOJ { get; set; }
    }
}
