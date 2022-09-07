using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace CRUDUsingAdoDotNet1.Models
{
    [Table("Product")] //Product model class map with /Product table in DB
    public class Employee
    {
        [Key]//defined that Id is PK col in table
        [ScaffoldColumn(false)]  //only ID PK col and identity col
        public int Id { get; set; }
        [Required(ErrorMessage = "name is required")]
        public string? Name { get; set; }// ? -allow null value

        [Required(ErrorMessage = "department name is required")]
        public string? DepartmentName { get; set; }
        [Required(ErrorMessage = "salary is required")]
        public int Salary { get; set; }
    }
}
