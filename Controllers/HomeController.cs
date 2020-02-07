using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Task_Web_Product.Models;

namespace Task_Web_Product.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private AppDbContext _AppDbContext;
        public HomeController(ILogger<HomeController> logger, AppDbContext appDbContext)
        {
            _logger = logger;
            _AppDbContext = appDbContext;
        }

        public IActionResult Index()
        {
            var items = from item in _AppDbContext.items where item.rate>=8 select item;
            ViewBag.items = items;
            return View();
        }

        public IActionResult Item()
        {
            var items = from item in _AppDbContext.items select item;
            ViewBag.items = items;
            return View();
        }
        public IActionResult Detail(int id)
        {
            var items = from item in _AppDbContext.items where item.id == id select item;
            ViewBag.items = items;
            return View("Detail");
        }

        public IActionResult Cart(int id)
        {
            var display = from x in _AppDbContext.carts from y in x.Items where y.CartsId==1 && y.total_item_in_cart>0 select y;
            ViewBag.items = display;
            return View("Cart");
        }

        public IActionResult Add(int id)
        {
            var findCarts = _AppDbContext.carts.Find(1);
            var findItem = _AppDbContext.items.Find(id);
            if (!_AppDbContext.carts.Any())
            {
                Carts cart = new Carts();
                _AppDbContext.carts.Add(cart);
                _AppDbContext.SaveChanges();
            }
            
            findItem.total_item_in_cart+=1;
            findItem.CartsId = findCarts.id;
            _AppDbContext.Add(findItem);
            _AppDbContext.Attach(findItem);
            _AppDbContext.SaveChanges();

            var display = from x in _AppDbContext.carts from y in x.Items where y.CartsId==1 && y.total_item_in_cart>0 select y;
            ViewBag.items = display;
            return RedirectToAction("Cart","Home");
        }
        public IActionResult Update(int id,int val)
        {
            var item = _AppDbContext.items.Find(id);
            item.total_item_in_cart=val;
            _AppDbContext.Add(item);
            _AppDbContext.Attach(item);
            _AppDbContext.SaveChanges();
            var display = from x in _AppDbContext.carts from y in x.Items where y.CartsId==1 && y.total_item_in_cart>0 select y;
            ViewBag.items = display;
            return RedirectToAction("Cart","Home");
        }
        public IActionResult Remove(int id)
        {
            var item = _AppDbContext.items.Find(id);
            item.total_item_in_cart=0;
            _AppDbContext.Add(item);
            _AppDbContext.Attach(item);
            _AppDbContext.SaveChanges();
            return RedirectToAction("Cart","Home");
        }
        public IActionResult Checkout(int sum)
        {
            var cart = _AppDbContext.carts.Find(1);
            cart.totalPrice=sum;
            _AppDbContext.Add(cart);
            _AppDbContext.Attach(cart);
            _AppDbContext.SaveChanges();
            return View("Checkout");

            // return RedirectToAction("Out","Home");
        }
        // public IActionResult Out()
        // {
        //     return View("Checkout");
        // }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
