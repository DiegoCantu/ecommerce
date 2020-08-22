using FluentValidation;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ecommerce.Models
{
    public class Address
    {
        //Primary Key Auto-Increment
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdAddress { get; set; } 
        //Foreign key for User
        public int IdUser { get; set; }
        public User User { get; set; }
        //Columns
        public string BuyerName { get; set; }
        public string Phone { get; set; }
        public string State { get; set; }
        public string City { get; set; }
        public string Street { get; set; }
        public string PostalCode { get; set; }
        public bool InUse { get; set; }
        public DateTime? CreateDate { get; set; } = DateTime.Now;
    }

    public class AddressValidation : AbstractValidator<Address>
    {
        public AddressValidation()
        {
            RuleFor(x => x.IdUser).NotEmpty();
            RuleFor(x => x.BuyerName).NotEmpty();
            RuleFor(x => x.Phone).NotEmpty();
            RuleFor(x => x.State).NotEmpty();
            RuleFor(x => x.City).NotEmpty();
            RuleFor(x => x.Street).NotEmpty();
            RuleFor(x => x.PostalCode).NotEmpty();
        }
    }
}
