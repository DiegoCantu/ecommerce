using System;

namespace ecommerce.DTOs.Response
{
    public class CardResponse
    {
        public int IdCard { get; set; }
        public string Email { get; set; }
        public string CardName { get; set; }
        public string UsernameCard { get; set; }
        public string NumberCard { get; set; }
        public string ExpireDate { get; set; }
        public bool InUse { get; set; }
        public DateTime? CreateDate { get; set; } = DateTime.Now;
    }
}
