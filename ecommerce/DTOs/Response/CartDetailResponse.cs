namespace ecommerce.DTOs.Response
{
    public class CartDetailResponse
    {
        public int IdCartDetail { get; set; }
        public int IdCart { get; set; }
        public int IdProduct { get; set; }
        public int Quantity { get; set; }
        public ProductResponse Product { get; set; }
    }
}
