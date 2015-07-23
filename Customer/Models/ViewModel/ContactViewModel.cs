using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Customer.Models.ViewModel
{
    public class ContactViewModel
    {
        public IPagedList<客戶聯絡人> Contacts { get; set; }
        public IQueryable<客戶資料> Customers { get; set; }

        public int PageIndex { get; set; }

        public ContactViewModel()
        {
            this.PageIndex = 1;
        }
    }
}