using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Customer.Models;
using Customer.Models.Interface;
using Customer.Models.Repository;

namespace Customer.Controllers
{
    public class ReportController : Controller
    {
        private IRepository<v_rpt1> rptRepository = new GenericRepository<v_rpt1>();
        // GET: /Report/
        public ActionResult Index()
        {
            return View(this.rptRepository.GetAll(null));
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                rptRepository.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
