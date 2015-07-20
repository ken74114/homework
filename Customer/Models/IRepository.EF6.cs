

using PagedList;
using System;
using System.Linq;
using System.Linq.Expressions;

namespace Customer.Models
{ 
	public interface IRepository<T> 
	{
		IUnitOfWork UnitOfWork { get; set; }
		IQueryable<T> All();
		IQueryable<T> Where(Expression<Func<T, bool>> expression);
		void Add(T entity);
		void Delete(T entity);
        
        T Find(int id);

        IPagedList<T> PagedToList(int pageIndex, int pageNum);

        IOrderedQueryable<T> Order();
    }
}

