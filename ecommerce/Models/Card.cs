using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ecommerce.Models
{
    public class Card
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key, Column(Order = 0)]
        public int IdCard { get; set; }
        [Key, Column(Order = 1)]
        public string Email { get; set; }
        public string CardName { get; set; }
        public string UsernameCard { get; set; }
        [Key, Column(Order = 2)]
        public string NumberCard { get; set; }
        public string ExpireDate { get; set; }
        public bool InUse { get; set; }
        public DateTime CreateDate { get; set; } = DateTime.Now;

        public virtual User User { get; set; }
    }
}
