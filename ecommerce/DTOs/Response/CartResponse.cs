using System;
using System.Collections.Generic;

namespace ecommerce.DTOs.Response
{
    public class CartResponse
    {
        public int IdCart { get; set; }
        public string Email { get; set; }
        public bool Bought { get; set; } = false;
        public decimal Total { get; set; }
        public DateTime? CreateDate { get; set; } = DateTime.Now;
        public ICollection<CartDetailResponse> CartDetails { get; set; }
    }
}
