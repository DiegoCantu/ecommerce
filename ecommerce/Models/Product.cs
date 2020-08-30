using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ecommerce.Models
{
    public class Product
    {
        public Product()
        {
            CartDetailProductAuxiliaryNn = new HashSet<CartDetailProductAuxiliaryNn>();
            Comment = new HashSet<Comment>();
        }

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public int IdProduct { get; set; }
        public int IdCategory { get; set; }
        public string Sku { get; set; }
        public string Title { get; set; }
        public string SubHeader { get; set; }
        public string Description { get; set; }
        public decimal UnitPrice { get; set; }
        public int Quantity { get; set; }
        public decimal Rating { get; set; }
        public string Img { get; set; }
        public bool ImgApproved { get; set; } = false;
        public DateTime CreateDate { get; set; } = DateTime.Now;

        public virtual Category Category { get; set; }
        public virtual ICollection<CartDetailProductAuxiliaryNn> CartDetailProductAuxiliaryNn { get; set; }
        public virtual ICollection<Comment> Comment { get; set; }
    } 
}
