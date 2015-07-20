
using PagedList;
namespace Customer.Models.ViewModel
{
    public class CustomerViewModel
    {
        public IPagedList<客戶資料> Customers { get; set; }
        public int PageIndex { get; set; }

        public CustomerViewModel()
        {
            this.PageIndex = 1;
        }
    }
}