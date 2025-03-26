using AutoMapper;
using Definex.Services.ProductAPI.Dtos;
using DefineX.Services.ProductAPI.Models;

namespace Definex.Services.ProductAPI;

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