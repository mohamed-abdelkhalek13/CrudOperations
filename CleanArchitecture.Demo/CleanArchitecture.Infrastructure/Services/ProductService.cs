using AutoMapper;
using CleanArchitecture.Application.Interfaces.UnitOfWork;
using CleanArchitecture.Domain.Entities;
using CleanArchitecture.Application.DTOs.Product;
using CleanArchitecture.Infrastructure.UnitOfWork;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CleanArchitecture.Application.Interfaces.Services;
using CleanArchitecture.Application;

namespace CleanArchitecture.Infrastructure.Services
{
    public class ProductService : IProductService
    {
        private readonly IUnitOfWork UnitOfWork;
        private readonly IMapper mapper; 
        public ProductService(IUnitOfWork UnitOfWork, IMapper mapper)
        {
            this.UnitOfWork = UnitOfWork;
            this.mapper = mapper;
        }

        public List<ProductDetailsDto> GetAllProducts()
        {
            var _list = UnitOfWork.ProductsRepository.GetAll().ToList();
           var productsList = mapper.Map<List<ProductDetailsDto>>(_list);

            return productsList;
        }


        public ProductDetailsDto GetProduct([FromRoute] int id)
        {
            var product = mapper.Map<ProductDetailsDto>(UnitOfWork.ProductsRepository.GetById(id));

            return product;
        }

        public int AddProduct([FromBody] CreateProductDto product)
        {
            try
            {
                var Entity = mapper.Map<Product>(product);
                UnitOfWork.ProductsRepository.Add(Entity);
                UnitOfWork.SaveChanges();
                return (int)OperationStatus.SuccessfullyDone;
            }
            catch(Exception ex)
            {
                return (int)OperationStatus.ServerErrorOccurs;
            }
        }


        public int UpdateProduct([FromRoute] int id, [FromBody] CreateProductDto product)
        {
            
            var OldProduct = UnitOfWork.ProductsRepository.GetById(id);
            if (OldProduct is null)
                return (int)OperationStatus.NotFound;

            try
            {
                mapper.Map(product, OldProduct);

                UnitOfWork.ProductsRepository.Update(OldProduct);
                UnitOfWork.SaveChanges();
                return (int)OperationStatus.SuccessfullyDone;
            }
            catch(Exception ex)
            {
                return (int)OperationStatus.ServerErrorOccurs;
            }
        }

        public int deleteProduct([FromRoute] int id)
        {
            try
            {
                UnitOfWork.ProductsRepository.Remove(id);
                UnitOfWork.SaveChanges();
                return (int)OperationStatus.SuccessfullyDone;
            }
            catch (Exception ex)
            {
                return (int)OperationStatus.ServerErrorOccurs;
            }
           
            
        }
    }
}
