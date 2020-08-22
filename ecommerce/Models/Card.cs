using FluentValidation;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ecommerce.Models
{
    public class Card
    {
        //Primary Key Auto-Increment
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdCard { get; set; }
        //Foreign key for User
        public int IdUser { get; set; }
        public User User { get; set; }
        //Columns
        public string CardName { get; set; }
        public string UsernameCard { get; set; }
        public string NumberCard { get; set; }
        public string ExpireDate { get; set; }
        public bool InUse { get; set; } 
        public DateTime? CreateDate { get; set; } = DateTime.Now;
    }

    public class CardValidation : AbstractValidator<Card>
    {
        public CardValidation()
        {
            RuleFor(x => x.IdUser).NotEmpty();
            RuleFor(x => x.CardName).NotEmpty();
            RuleFor(x => x.UsernameCard).NotEmpty();
            RuleFor(x => x.NumberCard).NotEmpty();
            RuleFor(x => x.ExpireDate).NotEmpty();
        }
    }
}
