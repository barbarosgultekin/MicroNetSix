using AutoMapper;
using MicroNetSix.Services.ProductAPI.Models;
using MicroNetSix.Services.ProductAPI.Models.Dto;
using MicroNetSix.Services.ProductAPI.Models.Dtos;

namespace MicroNetSix.Services.ProductAPI
{
    public class MappingConfig
    {
        public static MapperConfiguration RegisterMaps()
        {
            var mappingConfig = new MapperConfiguration(config =>
            {
                config.CreateMap<ProductDto, Product>();
                config.CreateMap<Product, ProductDto>();
            });
                return mappingConfig;
        }
    }
}
