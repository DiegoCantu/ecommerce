using System;
using System.Collections.Generic;

namespace ecommerce.DTOs.Response
{
    public class ProductResponse
    {
        public int IdProduct { get; set; }
        public int IdCategory { get; set; }
        public string Sku { get; set; }
        public string Title { get; set; }
        public string SubHeader { get; set; }
        public string Description { get; set; }
        public decimal UnitPrice { get; set; }
        public int Quantity { get; set; } = 1;
        public int Rating { get; set; }
        public string Img { get; set; }
        public bool ImgApproved { get; set; } = false;
        public DateTime? CreateDate { get; set; } = DateTime.Now;
        public ICollection<CommentResponse> Comments { get; set; }
    }
}
