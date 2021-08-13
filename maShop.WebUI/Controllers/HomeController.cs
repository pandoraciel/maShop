using maShop.core.Contracts;
using maShop.core.Models;
using maShop.core.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace maShop.WebUI.Controllers
{
    public class HomeController : Controller
    {
        IRepository<Product> context;
        IRepository<ProductCategory> productCategories;

        public HomeController(IRepository<Product> productContext, IRepository<ProductCategory> productCategoryContext)
        {
            //context = new InMemoryRepository<Product>();
            context = productContext;
            //productCategories = new InMemoryRepository<ProductCategory>();
            productCategories = productCategoryContext;
        }
        public ActionResult Index(string Category = null)
        {
            List<Product> products;// = context.Collection().ToList();
            List<ProductCategory> categories = productCategories.Collection().ToList();

            if (Category == null)
            {
                products = context.Collection().ToList();
            }
            else
            {
                products = context.Collection().Where(p => p.Category == Category).ToList();
            }

            ProductListViewModel viewModel = new ProductListViewModel();
            viewModel.Products = products;
            viewModel.ProductCategories = categories;

            return View(viewModel);
        }

        public ActionResult Detail(string Id)
        {
            Product product = context.Find(Id);
            return View(product);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}