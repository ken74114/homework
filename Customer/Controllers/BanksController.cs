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
    public class BanksController : Controller
    {
        //private CustomInfoEntities db = new CustomInfoEntities();
        private IRepository<客戶銀行資訊> bankRepository = new GenericRepository<客戶銀行資訊>();
        private IRepository<客戶資料> customerRepository = new GenericRepository<客戶資料>();
        // GET: /Banks/
        public ActionResult Index()
        {
            var 客戶銀行資訊 = this.bankRepository.GetAll(x => !x.是否已刪除 && !x.客戶資料.是否已刪除);
            return View(客戶銀行資訊);
        }

        // GET: /Banks/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            客戶銀行資訊 客戶銀行資訊 = this.bankRepository.Get(id);
            if (客戶銀行資訊 == null)
            {
                return HttpNotFound();
            }
            return View(客戶銀行資訊);
        }

        // GET: /Banks/Create
        public ActionResult Create()
        {
            ViewBag.客戶Id = new SelectList(this.customerRepository.GetAll(x => !x.是否已刪除), "Id", "客戶名稱");
            return View();
        }

        // POST: /Banks/Create
        // 若要免於過量張貼攻擊，請啟用想要繫結的特定屬性，如需
        // 詳細資訊，請參閱 http://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,客戶Id,銀行名稱,銀行代碼,分行代碼,帳戶名稱,帳戶號碼")] 客戶銀行資訊 客戶銀行資訊)
        {
            if (ModelState.IsValid)
            {
                this.bankRepository.Create(客戶銀行資訊);
                return RedirectToAction("Index");
            }
            ViewBag.客戶Id = new SelectList(this.customerRepository.GetAll(x => !x.是否已刪除), "Id", "客戶名稱", 客戶銀行資訊.客戶Id);
            return View(客戶銀行資訊);
        }

        // GET: /Banks/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            客戶銀行資訊 客戶銀行資訊 = this.bankRepository.Get(id);
            if (客戶銀行資訊 == null)
            {
                return HttpNotFound();
            }
            ViewBag.客戶Id = new SelectList(this.customerRepository.GetAll(x => !x.是否已刪除), "Id", "客戶名稱", 客戶銀行資訊.客戶Id);
            return View(客戶銀行資訊);
        }

        // POST: /Banks/Edit/5
        // 若要免於過量張貼攻擊，請啟用想要繫結的特定屬性，如需
        // 詳細資訊，請參閱 http://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,客戶Id,銀行名稱,銀行代碼,分行代碼,帳戶名稱,帳戶號碼")] 客戶銀行資訊 客戶銀行資訊)
        {
            if (ModelState.IsValid)
            {
                this.bankRepository.Update(客戶銀行資訊);
                return RedirectToAction("Index");
            }
            ViewBag.客戶Id = new SelectList(this.customerRepository.GetAll(x => !x.是否已刪除), "Id", "客戶名稱", 客戶銀行資訊.客戶Id);
            return View(客戶銀行資訊);
        }

        // GET: /Banks/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            客戶銀行資訊 客戶銀行資訊 = this.bankRepository.Get(id);
            if (客戶銀行資訊 == null)
            {
                return HttpNotFound();
            }
            return View(客戶銀行資訊);
        }

        // POST: /Banks/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            客戶銀行資訊 客戶銀行資訊 = this.bankRepository.Get(id);
            客戶銀行資訊.是否已刪除 = !客戶銀行資訊.是否已刪除;
            this.bankRepository.Delete(客戶銀行資訊);
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                this.customerRepository.Dispose();
                this.bankRepository.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
