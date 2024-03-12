using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitecture.Application.Interfaces.Repositories
{
    public interface IGenericRepository<T> where T: class
    {
        T GetById(int id);
        IEnumerable<T> Find(Expression<Func<T, bool>> where);
        IEnumerable<T> GetAll();
        void Add(T Entity);
        void AddRange (IEnumerable<T> Entities);
        void Remove(int id);
        void RemoveRange(IEnumerable<T> Entities);
        void Update(T Entity);
        void UpdateRange(IEnumerable<T> Entities);
    }
}
