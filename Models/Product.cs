using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace CRUDUsingAdoDotNet1.Models
{
    [Table("Product")] //Product model class map with /Product table in DB
    public class Product
    {
        [Key]//defined that Id is PK col in table
        [ScaffoldColumn(false)]  //only ID PK col and identity col
        public int Id { get; set; }
        [Required(ErrorMessage = "name is required")]
        public string? Name { get; set; }// ? -allow null value

        [Required(ErrorMessage = "Company name is required")]
        public string? CompanyName { get; set; }
        [Required(ErrorMessage = "Price is required")]
        public int Price { get; set; }
    }
}
