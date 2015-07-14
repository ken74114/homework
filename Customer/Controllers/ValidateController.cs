using Customer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Customer.Controllers
{
    public class ValidateController : Controller
    {
        private 客戶聯絡人Repository contactRepository = RepositoryHelper.Get客戶聯絡人Repository();
        public JsonResult CheckEmail(string email, int 客戶Id, int id=0)
        {
            bool isValidate = false;
            isValidate = this.contactRepository.IsRepeatForEmail(客戶Id, email, id);
            return Json(!isValidate, JsonRequestBehavior.AllowGet);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                this.contactRepository.UnitOfWork.Context.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}