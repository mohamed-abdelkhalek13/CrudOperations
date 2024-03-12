using CleanArchitecture.Application.DTOs.Product;
using CleanArchitecture.Domain.Entities;
using System;
using System.Buffers;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitecture.Application.Interfaces.Services
{
    public interface IProductService
    {

        List<ProductDetailsDto> GetAllProducts();


        ProductDetailsDto GetProduct(int id);

        int AddProduct(CreateProductDto product);


        int UpdateProduct(int id, CreateProductDto product);

        int deleteProduct(int id);
    }
}
