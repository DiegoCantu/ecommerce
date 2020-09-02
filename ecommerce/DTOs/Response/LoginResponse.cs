using System.Collections.Generic;

namespace ecommerce.DTOs.Response
{
    public class LoginResponse
    {
        public string Name { get; set; }
        public string LastName { get; set; }
        public string SecondLastName { get; set; }
        public string Email { get; set; } 
        public string JWT { get; set; }
        public IEnumerable<AddressResponse> Addresses { get; set; }
        public IEnumerable<CardResponse> Cards { get; set; }
        public IEnumerable<CartResponse> Carts { get; set; }
        public IEnumerable<PurchaseResponse> Purchases { get; set; }
    }
}
