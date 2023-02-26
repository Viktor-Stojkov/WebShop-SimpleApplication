using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebShop_Domain.Models
{
    [Table("Categories")]
    public class Categories
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int CategoryId { get; set; } //PK
        public string CategoryName { get; set; }
        public string Description { get; set; }
        public int Price { get; set; }
        public IEnumerable<Products> Products { get; set; }
    }
}
