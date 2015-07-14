using Customer.Models;
using System.Web.Mvc;

namespace Customer.Controllers
{
    public class ReportController : Controller
    {
        private v_rpt1Repository rptRepository = RepositoryHelper.Getv_rpt1Repository();
        // GET: /Report/
        public ActionResult Index()
        {
            return View(this.rptRepository.All());
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
               this. rptRepository.UnitOfWork.Context.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
