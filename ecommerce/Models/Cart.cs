using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ecommerce.Models
{
    public class Cart
    {
        public Cart()
        {
            CartDetail = new HashSet<CartDetail>();
        }

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public int IdCart { get; set; }
        public string Email { get; set; }
        public bool Bought { get; set; }
        public decimal Total { get; set; }
        public DateTime CreateDate { get; set; } = DateTime.Now;

        public virtual User User { get; set; }
        public virtual Purchase Purchase { get; set; }
        public virtual ICollection<CartDetail> CartDetail { get; set; }
    }
}
