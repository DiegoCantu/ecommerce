using System;

namespace ecommerce.DTOs.Response
{
    public class CommentResponse
    {
        public int IdComment { get; set; }
        public int IdProduct { get; set; }
        public int Rating { get; set; }
        public string Name { get; set; }
        public string Post { get; set; }
        public DateTime? CreateDate { get; set; } = DateTime.Now;
    }
}
