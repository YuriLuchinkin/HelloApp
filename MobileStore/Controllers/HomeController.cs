using System.Linq;
using Microsoft.AspNetCore.Mvc;
using MobileStore.Models;

namespace MobileStore.Controllers
{
    public class HomeController : Controller
    {
        MobileContext db;
        public HomeController(MobileContext context)
        {
            db = context;
        }
        public IActionResult Index()
        {
            return View(db.Phones.ToList());
        }
        [HttpGet]
        public IActionResult Buy(int? id)
        {
            if (id == null) return RedirectToAction("Index");
            ViewBag.PhoneId = id;
            return View();
        }
        [HttpPost]
        public string Buy(Order order)
        {
            db.Orders.Add(order);
            // сохраняем в бд все изменения
            db.SaveChanges();
            return "Спасибо, " + order.User + ", за покупку!";
        }

        [HttpGet]
        public IActionResult Order()
        {
            foreach (var o in db.Orders)
                foreach (var p in db.Phones)
                    if (p.Id == o.PhoneId)
                    {
                        o.Phone = p;
                        break;
                    }
            
            return View(db.Orders.ToList());
        }
    }
}