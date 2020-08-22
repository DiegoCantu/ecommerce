using FluentValidation;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ecommerce.Models
{
    public class Category
    {
        //Primary Key Auto-Increment
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdCategory { get; set; }
        public string Name { get; set; }
        public DateTime? CreateDate { get; set; } = DateTime.Now;
    }

    internal class CategoryValidation : AbstractValidator<Category>
    {
        public CategoryValidation()
        {
            RuleFor(x => x.Name).NotEmpty();
        }
    }
}
