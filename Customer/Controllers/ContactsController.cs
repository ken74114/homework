﻿using Customer.ActionFilters;
using Customer.Models;
using Customer.Models.ViewModel;
using System.Data.Entity;
using System.Net;
using System.Web.Mvc;

namespace Customer.Controllers
{
    [Shared]
    public class ContactsController : Controller
    {
        private 客戶聯絡人Repository contactRepository = RepositoryHelper.Get客戶聯絡人Repository();
        private 客戶資料Repository customerRepository = RepositoryHelper.Get客戶資料Repository();
        private int pageNum = 10;
        // GET: /Contacts/
        public ActionResult Index(ContactViewModel model)
        {
            model.Contacts = this.contactRepository.PagedToList(model.PageIndex, pageNum);
            model.Customers = this.customerRepository.All();
            return View(model);
        }

        // GET: /Contacts/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            客戶聯絡人 客戶聯絡人 = this.contactRepository.Find(id.Value);
            if (客戶聯絡人 == null)
            {
                return HttpNotFound();
            }
            return View(客戶聯絡人);
        }

        // GET: /Contacts/Create
        public ActionResult Create()
        {
            ViewBag.客戶Id = new SelectList(this.customerRepository.All(), "Id", "客戶名稱");
            return View();
        }

        // POST: /Contacts/Create
        // 若要免於過量張貼攻擊，請啟用想要繫結的特定屬性，如需
        // 詳細資訊，請參閱 http://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,客戶Id,職稱,姓名,Email,手機,電話")] 客戶聯絡人 客戶聯絡人)
        {
            if (ModelState.IsValid)
            {
                this.contactRepository.Add(客戶聯絡人);
                this.contactRepository.UnitOfWork.Commit();
                return RedirectToAction("Index");
            }

            ViewBag.客戶Id = new SelectList(this.customerRepository.All(), "Id", "客戶名稱", 客戶聯絡人.客戶Id);
            return View(客戶聯絡人);
        }

        // GET: /Contacts/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            客戶聯絡人 客戶聯絡人 = this.contactRepository.Find(id.Value);
            if (客戶聯絡人 == null)
            {
                return HttpNotFound();
            }
            ViewBag.客戶Id = new SelectList(this.customerRepository.All(), "Id", "客戶名稱", 客戶聯絡人.客戶Id);
            return View(客戶聯絡人);
        }

        // POST: /Contacts/Edit/5
        // 若要免於過量張貼攻擊，請啟用想要繫結的特定屬性，如需
        // 詳細資訊，請參閱 http://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,客戶Id,職稱,姓名,Email,手機,電話")] 客戶聯絡人 客戶聯絡人)
        {
            if (ModelState.IsValid)
            {
                this.contactRepository.UnitOfWork.Context.Entry(客戶聯絡人).State = System.Data.Entity.EntityState.Modified;
                this.contactRepository.UnitOfWork.Commit();
                return RedirectToAction("Index");
            }
            ViewBag.客戶Id = new SelectList(this.customerRepository.All(), "Id", "客戶名稱", 客戶聯絡人.客戶Id);
            return View(客戶聯絡人);
        }

        [HttpPost]
        public ActionResult Update(客戶聯絡人[] Contacts, int PageIndex)
        {
            if (ModelState.IsValid)
            {
                foreach (客戶聯絡人 data in Contacts)
                {
                    if (!data.IsDelete)
                    {
                        data.IsDelete = false;
                        }
                    else
                    {
                        data.是否已刪除 = !data.是否已刪除;
                    }
                    this.contactRepository.UnitOfWork.Context.Entry(data).State = EntityState.Modified;
                }
                this.contactRepository.UnitOfWork.Commit();
                return RedirectToAction("Index", new { PageIndex });
            }
            else
            {
                ContactViewModel model = new ContactViewModel();
                model.PageIndex = PageIndex;
                model.Contacts = this.contactRepository.PagedToList(PageIndex, pageNum);
                model.Customers = this.customerRepository.All();
                return View("Index", model);
            }
        }
        // GET: /Contacts/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            客戶聯絡人 客戶聯絡人 = this.contactRepository.Find(id.Value);
            if (客戶聯絡人 == null)
            {
                return HttpNotFound();
            }
            return View(客戶聯絡人);
        }

        // POST: /Contacts/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            客戶聯絡人 客戶聯絡人 = this.contactRepository.Find(id);
            this.contactRepository.Delete(客戶聯絡人);
            this.contactRepository.UnitOfWork.Commit();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                this.contactRepository.UnitOfWork.Context.Dispose();
                this.customerRepository.UnitOfWork.Context.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
