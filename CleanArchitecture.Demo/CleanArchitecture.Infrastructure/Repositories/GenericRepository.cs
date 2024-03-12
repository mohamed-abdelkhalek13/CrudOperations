using CleanArchitecture.Application.Interfaces.Repositories;
using CleanArchitecture.Infrastructure.DB;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitecture.Infrastructure.Repositories
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        private readonly ApplicationDbContext _dbContext;


        public GenericRepository(ApplicationDbContext _dbContext)
        {
            this._dbContext = _dbContext;
        }
        public void Add(T Entity)
        {
               _dbContext.Set<T>().Add(Entity);
        }

        public void AddRange(IEnumerable<T> Entities)
        {
            _dbContext.Set<T>().AddRange(Entities);
        }

        public IEnumerable<T> Find(Expression<Func<T, bool>> expression)
        {
            return _dbContext.Set<T>().Where(expression);
        }

        public IEnumerable<T> GetAll()
        {
            return _dbContext.Set<T>().AsNoTracking();
        }

        public T GetById(int id)
        {
            return _dbContext.Set<T>().Find(id);
        }

        public void Remove(int id)
        {
            var Entity = _dbContext.Set<T>().Find(id);
            if(Entity is not null)
                _dbContext.Set<T>().Remove(Entity);
        }

        public void RemoveRange(IEnumerable<T> Entities)
        {
            _dbContext.Set<T>().RemoveRange(Entities);
        }

        public void Update(T Entity)
        {
            _dbContext.Set<T>().Update(Entity);
        }

        public void UpdateRange(IEnumerable<T> Entities)
        {
            _dbContext.Set<T>().UpdateRange(Entities);
        }
    }
}
