using System;

namespace ecommerce.DTOs.Response
{
    public class CategoryResponse
    {
        public int IdCategory { get; set; }
        public string Name { get; set; }
        public DateTime? CreateDate { get; set; } = DateTime.Now;
    }
}
