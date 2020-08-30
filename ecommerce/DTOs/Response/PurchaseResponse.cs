using System;

namespace ecommerce.DTOs.Response
{
    public class PurchaseResponse
    {
        public int IdPurchase { get; set; }
        public string Email { get; set; }
        public int IdCart { get; set; }
        public CartResponse Cart { get; set; }
        public DateTime? CreateDate { get; set; } = DateTime.Now;
    }
}
