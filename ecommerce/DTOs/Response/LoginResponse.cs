using System.Collections.Generic;

namespace ecommerce.DTOs.Response
{
    public class LoginResponse
    {
        public string JWT { get; set; }
        public IEnumerable<AddressResponse> Addresses { get; set; }
        public IEnumerable<CardResponse> Cards { get; set; }
        public IEnumerable<CartResponse> Carts { get; set; }
        public IEnumerable<PurchaseResponse> Purchases { get; set; }
    }
}
