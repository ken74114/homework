using Customer.Models;
using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Customer.Models.ViewModel
{
    public class BankViewModel
    {
        public IPagedList<客戶銀行資訊> Banks { get; set; }

        public int PageIndex { get; set; }

        public BankViewModel()
        {
            this.PageIndex = 1;
        }
    }
}