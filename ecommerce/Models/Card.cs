using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ecommerce.Models
{
    public class Card
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public int IdCard { get; set; }
        public string Email { get; set; }
        public string CardName { get; set; }
        public string UsernameCard { get; set; }
        public string NumberCard { get; set; }
        public string ExpireDate { get; set; }
        public bool InUse { get; set; }
        public DateTime CreateDate { get; set; } = DateTime.Now;

        public virtual User User { get; set; }
    }
}
