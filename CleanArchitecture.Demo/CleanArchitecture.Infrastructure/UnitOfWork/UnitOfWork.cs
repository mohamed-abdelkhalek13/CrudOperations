using CleanArchitecture.Application.Interfaces.Repositories;
using CleanArchitecture.Application.Interfaces.UnitOfWork;
using CleanArchitecture.Infrastructure.DB;
using CleanArchitecture.Infrastructure.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitecture.Infrastructure.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext _dbContext;
        public IProductsRepository ProductsRepository { get; }


        public UnitOfWork(ApplicationDbContext _dbContext)
        {
            this._dbContext = _dbContext;
            ProductsRepository = new ProductsRepository(_dbContext);
        }


        public void Dispose()
        {
            _dbContext.Dispose();
        }

        public void SaveChanges()
        {
            _dbContext.SaveChanges();
        }
    }
}
