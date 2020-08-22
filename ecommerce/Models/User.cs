using FluentValidation;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ecommerce.Models
{
    public class User
    {
        //Auto-Increment
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdUser { get; set; }
        //Columns
        public string Username { get; set; }
        //Primary Key
        [Key]
        [Required]
        public string Email { get; set; }
        public string Password { get; set; }
        public DateTime? CreateDate { get; set; } = DateTime.Now;
        // Reference 1:N
        public ICollection<Address> Addresses { get; set; }
        public ICollection<Card> Cards { get; set; } 
    }

    internal class UserValidation : AbstractValidator<User>
    {
        public UserValidation()
        {
            RuleFor(x => x.Username).NotEmpty();
            RuleFor(x => x.Email).NotEmpty();
            RuleFor(x => x.Password).NotEmpty();
        }
    }
}
