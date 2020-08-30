using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ecommerce.Models
{
    public class Category
    {
        public Category()
        {
            Product = new HashSet<Product>();
        }

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public int IdCategory { get; set; }
        public string Name { get; set; }
        public DateTime CreateDate { get; set; } = DateTime.Now;

        public virtual ICollection<Product> Product { get; set; }
    }
}
