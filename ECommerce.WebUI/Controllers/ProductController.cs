using ECommerce.Business.Abstract;
using ECommerce.Entities.Models;
using ECommerce.WebUI.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ECommerce.WebUI.Controllers
{
    public class ProductController : Controller
    {
        private IProductService _productService;

        public ProductController(IProductService productService)
        {
            _productService = productService;
        }
        public async Task<ActionResult> Index(int category = 0)
        {
            ViewBag.SortByNameButtonText = "Sort A-Z";
            ViewBag.SortByPriceButtonText = "Lower To Higher";
            var products = await _productService.GetAllByCategory(category);
            var model = new ProductListViewModel
            {
                Products = products,
            };
            return View(model);
        }

        public async Task<ActionResult> Sort(string content)
        {
            var products = await _productService.GetAll();

            if (content == "Sort A-Z")
            {
                products = products.OrderBy(p => p.ProductName).ToList();
                content = "Sort Z-A";
            }
            else
            {
                products = products.OrderByDescending(p => p.ProductName).ToList();
                content = "Sort A-Z";
            }

            var model = new ProductListViewModel
            {
                Products = products,
            };

            ViewBag.SortByNameButtonText = content;

            return View("Index", model);
        }

        public async Task<ActionResult> SortPrice(string content)
        {
            var products = await _productService.GetAll();


            if (content == "Lower To Higher")
            {
                products = products.OrderBy(p => p.UnitPrice).ToList();
                content = "Higher To Lower";
            }
            else
            {
                products = products.OrderByDescending(p => p.UnitPrice).ToList();
                content = "Lower To Higher";
            }

            var model = new ProductListViewModel
            {
                Products = products,
            };

            ViewBag.SortByPriceButtonText = content;

            return View("Index", model);
        }

        // GET: ProductController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: ProductController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ProductController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
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

        // GET: ProductController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: ProductController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
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
