using System;
using System.Linq;
using System.Collections.Generic;

namespace Customer.Models
{
    public class 客戶資料Repository : EFRepository<客戶資料>, I客戶資料Repository
    {
        public override IQueryable<客戶資料> All()
        {
            return base.All().Where(x => !x.是否已刪除);
        }

        public override 客戶資料 Find(int id)
        {
            return this.All().FirstOrDefault(x => x.Id == id);
        }

        public override void Delete(客戶資料 entity)
        {
            entity.是否已刪除 = !entity.是否已刪除;
            this.UnitOfWork.Context.Entry(entity).State = System.Data.Entity.EntityState.Modified;
        }

        public override IOrderedQueryable<客戶資料> Order()
        {
            return this.All().OrderBy(x => x.Id);
        }
    }

    public interface I客戶資料Repository : IRepository<客戶資料>
    {

    }
}