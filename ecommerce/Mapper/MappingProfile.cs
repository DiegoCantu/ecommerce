using AutoMapper;
using ecommerce.DTOs.Response;
using ecommerce.Models;

namespace ecommerce.Mapper
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Address, AddressResponse>();
            CreateMap<Card, CardResponse>();
            CreateMap<Cart, CartResponse>();
            CreateMap<CartDetail, CartDetailResponse>();
            CreateMap<Category, CategoryResponse>();
            CreateMap<Comment, CommentResponse>();
            CreateMap<Product, ProductResponse>();
            CreateMap<Purchase, PurchaseResponse>();
            CreateMap<User, UserResponse>();
        }
    }
}
