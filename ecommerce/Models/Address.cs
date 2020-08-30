using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ecommerce.Models
{
    public class Address
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public int IdAddress { get; set; }
        public string Email { get; set; }
        public string BuyerName { get; set; }
        public string Phone { get; set; }
        public string State { get; set; }
        public string City { get; set; }
        public string Street { get; set; }
        public string PostalCode { get; set; }
        public bool InUse { get; set; }
        public DateTime CreateDate { get; set; } = DateTime.Now;

        //Foreign Key
        public virtual User User { get; set; }
    }

}
