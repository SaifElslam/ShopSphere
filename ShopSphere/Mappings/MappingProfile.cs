using AutoMapper;
using ShopSphere.DTOs;
using ShopSphere.Models;
namespace ShopSphere.Mappings
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Product, ProductDto>();
            CreateMap<CreateProductDto, Product>();
            CreateMap<UpdateProductDto, Product>();
        }
    }
}
