﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TimelyDepotMVC.Models.Admin;
using TimelyDepotMVC.DAL;
using PagedList;

namespace TimelyDepotMVC.Controllers.Admin
{
    public class PurchasOrderDetailAdminController : Controller
    {
        private TimelyDepotContext db = new TimelyDepotContext();

        int _pageIndex = 0;
        public int PageIndex
        {
            get { return _pageIndex; }
            set { _pageIndex = value; }
        }

        int _pageSize = 25;
        public int PageSize
        {
            get { return _pageSize; }
            set { _pageSize = value; }
        }

        //
        // GET: /PurchasOrderDetailAdmin/

        public ActionResult Index(int? page)
        {
            int pageIndex = 0;
            int pageSize = PageSize;
            IQueryable<PurchasOrderDetail> qryVendors = null;

            List<PurchasOrderDetail> VendorsList = new List<PurchasOrderDetail>();

            qryVendors = db.PurchasOrderDetails.OrderBy(vd => vd.PurchaseOrderId);
            if (qryVendors.Count() > 0)
            {
                foreach (var item in qryVendors)
                {
                    VendorsList.Add(item);
                }
            }

            //Set the page
            if (page == null)
            {
                pageIndex = 1;
            }
            else
            {
                pageIndex = Convert.ToInt32(page);
            }


            var onePageOfData = VendorsList.ToPagedList(pageIndex, pageSize);
            ViewBag.OnePageOfData = onePageOfData;
            return View(VendorsList.ToPagedList(pageIndex, pageSize));
            //return View(db.PurchasOrderDetails.ToList());
        }

        //
        // GET: /PurchasOrderDetailAdmin/Details/5

        public ActionResult Details(int id = 0)
        {
            PurchasOrderDetail purchasorderdetail = db.PurchasOrderDetails.Find(id);
            if (purchasorderdetail == null)
            {
                return HttpNotFound();
            }
            return View(purchasorderdetail);
        }

        //
        // GET: /PurchasOrderDetailAdmin/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /PurchasOrderDetailAdmin/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(PurchasOrderDetail purchasorderdetail)
        {
            if (ModelState.IsValid)
            {
                db.PurchasOrderDetails.Add(purchasorderdetail);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(purchasorderdetail);
        }

        //
        // GET: /PurchasOrderDetailAdmin/Edit/5

        public ActionResult Edit(int id = 0)
        {
            PurchasOrderDetail purchasorderdetail = db.PurchasOrderDetails.Find(id);
            if (purchasorderdetail == null)
            {
                return HttpNotFound();
            }
            return View(purchasorderdetail);
        }

        //
        // POST: /PurchasOrderDetailAdmin/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(PurchasOrderDetail purchasorderdetail)
        {
            if (ModelState.IsValid)
            {
                db.Entry(purchasorderdetail).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(purchasorderdetail);
        }

        //
        // GET: /PurchasOrderDetailAdmin/Delete/5

        public ActionResult Delete(int id = 0)
        {
            PurchasOrderDetail purchasorderdetail = db.PurchasOrderDetails.Find(id);
            if (purchasorderdetail == null)
            {
                return HttpNotFound();
            }
            return View(purchasorderdetail);
        }

        //
        // POST: /PurchasOrderDetailAdmin/Delete/5

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            PurchasOrderDetail purchasorderdetail = db.PurchasOrderDetails.Find(id);
            db.PurchasOrderDetails.Remove(purchasorderdetail);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}