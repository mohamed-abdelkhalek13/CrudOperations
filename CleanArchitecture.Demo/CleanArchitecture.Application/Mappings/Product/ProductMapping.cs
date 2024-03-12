using AutoMapper;
using CleanArchitecture.Application.DTOs.Product;
using Entity = CleanArchitecture.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitecture.Application.Mappings.Product
{
    public class ProductMapping : Profile
    {
        public ProductMapping()
        {
            CreateMap<Entity.Product, ProductDetailsDto>().ReverseMap();
            CreateMap<CreateProductDto, Entity.Product>().ReverseMap();
        }
    }
}
