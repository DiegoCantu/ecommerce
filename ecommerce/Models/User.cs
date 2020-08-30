using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ecommerce.Models
{
    public class User
    {
        public User()
        {
            Address = new HashSet<Address>();
            Card = new HashSet<Card>();
            Cart = new HashSet<Cart>();
            Purchase = new HashSet<Purchase>();
        }

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdUser { get; set; }
        [Key]
        public string Email { get; set; }
        public string Password { get; set; }
        public DateTime CreateDate { get; set; } = DateTime.Now;

        public virtual ICollection<Address> Address { get; set; }
        public virtual ICollection<Card> Card { get; set; }
        public virtual ICollection<Cart> Cart { get; set; }
        public virtual ICollection<Purchase> Purchase { get; set; }
    }
}
