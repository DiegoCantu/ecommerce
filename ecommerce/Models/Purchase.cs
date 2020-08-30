using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ecommerce.Models
{
    public class Purchase
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public int IdPurchase { get; set; }
        public string Email { get; set; }
        public int IdCart { get; set; }
        public DateTime CreateDate { get; set; } = DateTime.Now;

        public virtual User User { get; set; }
        public virtual Cart Cart { get; set; }
    }
}
