using CleanArchitecture.Application.Interfaces.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitecture.Application.Interfaces.UnitOfWork
{
    public interface IUnitOfWork : IDisposable
    {
        IProductsRepository ProductsRepository { get; }


        void SaveChanges();
    }
}
