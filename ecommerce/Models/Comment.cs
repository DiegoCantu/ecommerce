using FluentValidation;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ecommerce.Models
{
    public class Comment
    {
        //Primary Key Auto-Increment
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdComment { get; set; }
        //Foreign key for Product
        public int IdProduct { get; set; }
        public Product Product { get; set; }
        // Columns
        public int Rating { get; set; }
        public string Name { get; set; }
        public string Post { get; set; }
        public DateTime? CreateDate { get; set; } = DateTime.Now;
    }

    public class CommentValidation : AbstractValidator<Comment>
    {
        public CommentValidation() 
        {
            RuleFor(x => x.IdProduct).NotEmpty();
            RuleFor(x => x.Rating).NotEmpty();
            RuleFor(x => x.Name).NotEmpty();
            RuleFor(x => x.Post).NotEmpty();
        }
    }
}
