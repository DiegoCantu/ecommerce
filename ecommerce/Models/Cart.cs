using FluentValidation;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ecommerce.Models
{
    public class Cart
    {
        //Primary Key Auto-Increment
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdCart { get; set; }
        //Foreign key for User
        public int IdUser { get; set; }
        public User User { get; set; }
        //Columns
        public DateTime? CreateDate { get; set; } = DateTime.Now;
        // Reference to CartDetail table
        public ICollection<CartDetail> CartDetails { get; set; }
    }

    public class CartValidation : AbstractValidator<Cart>
    {
        public CartValidation()
        {
            RuleFor(x => x.IdUser).NotEmpty();
        }
    }
}
