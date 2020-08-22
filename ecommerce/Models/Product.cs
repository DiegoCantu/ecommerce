using FluentValidation;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ecommerce.Models
{
    public class Product
    {
        //Primary Key Auto-Increment
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdProduct {get;set;}
        //Foreign key for Category
        public int IdCategory { get; set; }
        public Category Category { get; set; }
        //Columns
        public string Sku { get; set; }
        public string Title { get; set; }
        public string SubHeader { get; set; }
        public string Description { get; set; }
        public decimal UnitPrice { get; set; }
        public int Quantity { get; set; } = 1;
        public int Rating { get; set; }
        public string Img { get; set; }
        public DateTime? CreateDate { get; set; } = DateTime.Now;
        // Reference 1:N
        public ICollection<Comment> Comments { get; set; }
    }

    internal class ProductValidation : AbstractValidator<Product>
    {
        public ProductValidation()
        {
            RuleFor(x => x.IdCategory).NotEmpty();
            RuleFor(x => x.Sku).NotEmpty();
            RuleFor(x => x.Title).NotEmpty();
            RuleFor(x => x.SubHeader).NotEmpty();
            RuleFor(x => x.Description).NotEmpty();
            RuleFor(x => x.UnitPrice).NotEmpty();
            RuleFor(x => x.Rating).NotEmpty();
            RuleFor(x => x.Img).NotEmpty();
        }
    }
}
