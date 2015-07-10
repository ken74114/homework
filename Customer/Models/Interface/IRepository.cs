using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Customer.Models.Interface
{
    public interface IRepository<TEntity> : IDisposable
        where TEntity : class
    {
        void Create(TEntity instance);

        void Update(TEntity instance);

        void Delete(TEntity instance);

        TEntity Get(int? id);

        IQueryable<TEntity> GetAll(Expression<Func<TEntity, bool>> predicate);

        void SaveChanges();

    }
}
