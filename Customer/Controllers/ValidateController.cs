using Customer.Models;
using Customer.Models.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Customer.Controllers
{
    public class ValidateController : Controller
    {
        private ValidateRepository<客戶聯絡人> contactRepository = new ValidateRepository<客戶聯絡人>();
        public JsonResult CheckEmail(string email, int 客戶Id)
        {
            bool isValidate = false;
            isValidate = this.contactRepository.IsRepeatForEmail(x => x.客戶Id == 客戶Id && x.Email.Equals(email));
            return Json(!isValidate, JsonRequestBehavior.AllowGet);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                this.contactRepository.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}