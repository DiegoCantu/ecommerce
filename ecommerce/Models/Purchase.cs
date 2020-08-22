using FluentValidation;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ecommerce.Models
{
    public class Purchase
    {
        //Primary Key Auto-Increment
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdPurchase { get; set; }
        //Foreign key for Cart
        public int IdCart { get; set; }
        public Cart Cart { get; set; }
        //Columns
        public decimal Total { get; set; }
        public DateTime? CreateDate { get; set; } = DateTime.Now;
    }

    public class PurchaseValidation : AbstractValidator<Purchase>
    {
        public PurchaseValidation()
        {
            RuleFor(x => x.IdCart).NotEmpty();
            RuleFor(x => x.Total).NotEmpty();
        }
    }
}
