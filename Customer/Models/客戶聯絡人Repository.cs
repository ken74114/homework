using System;
using System.Linq;
using System.Collections.Generic;

namespace Customer.Models
{
    public class 客戶聯絡人Repository : EFRepository<客戶聯絡人>, I客戶聯絡人Repository
    {
        public override IQueryable<客戶聯絡人> All()
        {
            return base.All().Where(x => !x.是否已刪除 && !x.客戶資料.是否已刪除);
        }

        public override 客戶聯絡人 Find(int id)
        {
            return this.All().FirstOrDefault(x => x.Id == id);
        }

        public override void Delete(客戶聯絡人 entity)
        {
            entity.是否已刪除 = !entity.是否已刪除;
            this.UnitOfWork.Context.Entry(entity).State = System.Data.Entity.EntityState.Modified;
        }

        public override IOrderedQueryable<客戶聯絡人> Order()
        {
            return this.All().OrderBy(x => x.Id);
        }

        public bool IsRepeatForEmail(int 客戶Id, string email, int id)
        {
            客戶聯絡人 data= base.All().Where(x => x.客戶Id == 客戶Id && x.Email.Equals(email)).FirstOrDefault() ;
            if (data == null) return false;
            if (data.Id == id) return false;
            return true;
        }
    }

    public interface I客戶聯絡人Repository : IRepository<客戶聯絡人>
    {

    }
}