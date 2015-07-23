using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Customer.Models;
using Customer.Models.ViewModel;

namespace Customer.Controllers
{
    public class BanksController : Controller
    {
        private 客戶銀行資訊Repository bankRepository = RepositoryHelper.Get客戶銀行資訊Repository();
        private 客戶資料Repository customerRepository = RepositoryHelper.Get客戶資料Repository();
        private int pageNum = 10;
        // GET: /Banks/
        public ActionResult Index(BankViewModel model)
        {
            model.Banks = this.bankRepository.PagedToList(model.PageIndex, pageNum);
            model.Customers = this.customerRepository.All();
            return View(model);
        }

        // GET: /Banks/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            客戶銀行資訊 客戶銀行資訊 = this.bankRepository.Find(id.Value);
            if (客戶銀行資訊 == null)
            {
                return HttpNotFound();
            }
            return View(客戶銀行資訊);
        }

        // GET: /Banks/Create
        public ActionResult Create()
        {
            ViewBag.客戶Id = new SelectList(this.customerRepository.All(), "Id", "客戶名稱");
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
                this.bankRepository.Add(客戶銀行資訊);
                this.bankRepository.UnitOfWork.Commit();
                return RedirectToAction("Index");
            }
            ViewBag.客戶Id = new SelectList(this.customerRepository.All(), "Id", "客戶名稱", 客戶銀行資訊.客戶Id);
            return View(客戶銀行資訊);
        }

        // GET: /Banks/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            客戶銀行資訊 客戶銀行資訊 = this.bankRepository.Find(id.Value);
            if (客戶銀行資訊 == null)
            {
                return HttpNotFound();
            }
            ViewBag.客戶Id = new SelectList(this.customerRepository.All(), "Id", "客戶名稱", 客戶銀行資訊.客戶Id);
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
                this.bankRepository.UnitOfWork.Context.Entry(客戶銀行資訊).State = System.Data.Entity.EntityState.Modified;
                this.bankRepository.UnitOfWork.Commit();
                return RedirectToAction("Index");
            }
            ViewBag.客戶Id = new SelectList(this.customerRepository.All(), "Id", "客戶名稱", 客戶銀行資訊.客戶Id);
            return View(客戶銀行資訊);
        }

        [HttpPost]
        public ActionResult Update(客戶銀行資訊[] Banks, int PageIndex)
        {
            if (ModelState.IsValid)
            {
                foreach (客戶銀行資訊 data in Banks)
                {
                    if (!data.IsDelete)
                    {
                        data.IsDelete = false;
                    }
                    else
                    {
                        data.是否已刪除 = !data.是否已刪除;
                    }
                    this.bankRepository.UnitOfWork.Context.Entry(data).State = EntityState.Modified;
                }
                this.bankRepository.UnitOfWork.Commit();
                return RedirectToAction("Index", new { PageIndex });
            }
            else
            {
                BankViewModel model = new BankViewModel();
                model.PageIndex = PageIndex;
                model.Banks = this.bankRepository.PagedToList(PageIndex, pageNum);
                model.Customers = this.customerRepository.All();
                return View("Index", model);
            }
        }

        // GET: /Banks/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            客戶銀行資訊 客戶銀行資訊 = this.bankRepository.Find(id.Value);
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
            客戶銀行資訊 客戶銀行資訊 = this.bankRepository.Find(id);
            this.bankRepository.Delete(客戶銀行資訊);
            this.bankRepository.UnitOfWork.Commit();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                this.customerRepository.UnitOfWork.Context.Dispose();
                this.bankRepository.UnitOfWork.Context.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
