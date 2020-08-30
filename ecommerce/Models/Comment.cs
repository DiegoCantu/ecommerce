using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ecommerce.Models
{
    public class Comment
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public int IdComment { get; set; }
        public int IdProduct { get; set; }
        public decimal Rating { get; set; }
        public string Name { get; set; }
        public string Post { get; set; }
        public DateTime CreateDate { get; set; } = DateTime.Now;

        public virtual Product Product { get; set; }
    }
}
