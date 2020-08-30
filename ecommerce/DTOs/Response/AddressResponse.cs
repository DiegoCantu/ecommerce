using System;

namespace ecommerce.DTOs.Response
{
    public class AddressResponse
    {
        public int IdAddress { get; set; }
        public string Email { get; set; }
        public string BuyerName { get; set; }
        public string Phone { get; set; }
        public string State { get; set; }
        public string City { get; set; }
        public string Street { get; set; }
        public string PostalCode { get; set; }
        public bool InUse { get; set; }
        public DateTime? CreateDate { get; set; } = DateTime.Now;
    }
}
