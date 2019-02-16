using DataLayer;
using ProductDetailsMVC.Models;
using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ProductDetailsMVC.Controllers
{
    public class HomeController : Controller
    {
        //
        // GET: /Home/
        public ActionResult Index()
        {

            ViewModel mymodel = new ViewModel();

            ProductHelper ph = new ProductHelper();
            SupplierHelper sh = new SupplierHelper();

            mymodel.Suppliers = sh.GetSupplierDetails();
            mymodel.Products = ph.GetProductDetails().ToList();
            return View(mymodel);
        }
        [HttpGet]
        public ActionResult CreateProduct()
        {
            ViewBag.SupplierID = new SupplierHelper().GetSupplierDetails().ToList();
            return View();
        }
        [HttpPost]
        [ActionName("CreateProduct")]
        public ActionResult CreateProduct_Post()
        {
            ProductDetails pd = new ProductDetails();
            if (ModelState.IsValid)
            {
                TryUpdateModel(pd);
                new ProductHelper().AddProductDetails(pd);
                return RedirectToAction("Index");
            }
            return View();
        }
        [HttpGet]
        public ActionResult EditProduct(int Id)
        {
            ViewBag.SupplierID = new SupplierHelper().GetSupplierDetails().ToList();
            ProductDetails pd = new ProductHelper().SearachProductDetails(Id);
            return View(pd);
        }
        
        [HttpPost]
        [ActionName("EditProduct")]
        public ActionResult EditProduct_Post()
        {
            ProductDetails pd = new ProductDetails();
            if (ModelState.IsValid)
            {
                TryUpdateModel(pd);
                new ProductHelper().EditProductDetails(pd);
                return RedirectToAction("Index");
            }
            return View();
        }
        [HttpGet]
        public ActionResult DetailsProduct(int Id)
        {
            ViewBag.SupplierID = new SupplierHelper().GetSupplierDetails().ToList();
            ProductDetails pd = new ProductHelper().SearachProductDetails(Id);
            return View(pd);
        }
        [HttpGet]
        public ActionResult DeleteProduct(int Id)
        {
            ViewBag.SupplierID = new SupplierHelper().GetSupplierDetails().ToList();
            new ProductHelper().DeleteProductDetails(Id);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult CreateSupplier()
        {
            ViewBag.SupplierID = new SelectList(new SupplierHelper().GetSupplierDetails().Select(x => x.SupplierId).ToList(), "SupplierId", "SupplierId");
            return View();
        }
        [HttpPost]
        [ActionName("CreateSupplier")]
        public ActionResult CreateSupplier_Post()
        {
            Supplierinfo si = new Supplierinfo();
            if (ModelState.IsValid)
            {
                TryUpdateModel(si);
                SupplierHelper sh = new SupplierHelper();
                sh.AddSupplierDetails(si);
                return RedirectToAction("Index");
            }
            return View();
        }
        [HttpGet]
        public ActionResult EditSupplier(int Id)
        {
            SupplierHelper sh = new SupplierHelper();
            Supplierinfo si = sh.SearchSupplierDetails(Id);
            return View(si);
        }
        [HttpPost]
        [ActionName("EditSupplier")]
        public ActionResult EditSupplier_Post()
        {
            Supplierinfo si = new Supplierinfo();
            if (ModelState.IsValid)
            {
                TryUpdateModel(si);
                SupplierHelper sh = new SupplierHelper();
                sh.EditSupplierDetails(si);
                return RedirectToAction("Index");
            }
            return View();
        }
        [HttpGet]
        public ActionResult DetailsSupplier(int Id)
        {
            SupplierHelper sh = new SupplierHelper();
            Supplierinfo si = sh.SearchSupplierDetails(Id);
            return View(si);
        }
        [HttpGet]
        public ActionResult DeleteSupplier(int Id)
        {
            SupplierHelper sh = new SupplierHelper();
            sh.DeleteSupplierDetails(Id);
            return RedirectToAction("Index");
        }
    }
}