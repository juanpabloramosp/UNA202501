using FrontEnd.Helpers.Interfaces;
using FrontEnd.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FrontEnd.Controllers
{
    public class ProductController : Controller
    {

        IProductHelper _productHelper;
        ICategoryHelper _categoryHelper;
        ISupplierHelper _supplierHelper;
        public ProductController(IProductHelper productHelper,
            ICategoryHelper categoryHelper
            ,ISupplierHelper supplierHelper)
        {
                this._productHelper = productHelper;
            this._categoryHelper = categoryHelper;
            this._supplierHelper = supplierHelper;
        }
        // GET: ProductController
        public ActionResult Index()
        {
            var lista = _productHelper.GetProducts();
            return View(lista);
        }

        // GET: ProductController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: ProductController/Create
        public ActionResult Create()
        {
            var product = new ProductViewModel();
            product.Categories = _categoryHelper.GetCategories();
            product.Suppliers = _supplierHelper.Get();
            return View(product);
        }

        // POST: ProductController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(ProductViewModel product)
        {
            try
            {
                _productHelper.Add(product);    
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: ProductController/Edit/5
        public ActionResult Edit(int id)
        {
            var product = _productHelper.Get(id);
            product.Categories = _categoryHelper.GetCategories();
            product.Suppliers = _supplierHelper.Get();

            return View(product);
        }

        // POST: ProductController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(ProductViewModel product)
        {
            try
            {
                _productHelper.Update(product);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: ProductController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: ProductController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
