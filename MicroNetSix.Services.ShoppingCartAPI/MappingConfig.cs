using AutoMapper;
using MicroNetSix.Services.ShoppingCartAPI.Models;
using MicroNetSix.Services.ShoppingCartAPI.Models.Dto;

namespace MicroNetSix.Services.ShoppingCartAPI
{
    public class MappingConfig
    {
        public static MapperConfiguration RegisterMaps()
        {
            var mappingConfig = new MapperConfiguration(config =>
            {
                config.CreateMap<ProductDto, Product>().ReverseMap();
                config.CreateMap<CartHeader, CartHeaderDto>().ReverseMap();
                config.CreateMap<CartDetails, CartDetailsDto>().ReverseMap();
                config.CreateMap<Cart, CartDto>().ReverseMap();
            });
            return mappingConfig;
        }
    }
}
