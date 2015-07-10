using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Web;

namespace Customer.Models.Repository
{
    public class ValidateRepository<TEntity> : IDisposable
         where TEntity : class
    {
        private DbContext _context
        {
            get;
            set;
        }
        public ValidateRepository() : this(new CustomInfoEntities()) { }

        private ValidateRepository(DbContext context)
        {
            _context = context;
        }

        public bool IsRepeatForEmail(Expression<Func<TEntity, bool>> predicate)
        {
            return (this._context.Set<TEntity>().Where(predicate).Count() > 0);

        }

        public void Dispose()
        {
            this.Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (this._context != null)
                {
                    this._context.Dispose();
                    this._context = null;
                }
            }
        }

    }
}