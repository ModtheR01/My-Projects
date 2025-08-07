using ITI_Project.Context;
using ITI_Project.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace ITI_Project.Controllers
{
    public class ProductController : Controller
    {
        MyContext db=new MyContext();
        [HttpGet]
        public IActionResult Index()
        {
            var products = db.Products.Include(p=>p.Category);
            return View(products);
        }
        [HttpGet]
        public IActionResult Details(int id)
        {
            var product = db.Products.Include(p=>p.Category).FirstOrDefault(p=>p.Id == id);
            return View(product);
        }
        [HttpGet]
        public IActionResult Create()
        {
            ViewBag.categories = new SelectList(db.Categories, "Id", "Name");
            return View();
        }
        [HttpPost]
        public IActionResult Create(Product product)
        {
            var existName = db.Products.FirstOrDefault(p => p.Title == product.Title);
            if (existName != null)
            {
                ModelState.AddModelError("", "Product Title Already Exist");
                ViewBag.categories = new SelectList(db.Categories, "Id", "Name");
                return View();
            }
            if (product != null)
            {
                db.Products.Add(product);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.categories = new SelectList(db.Categories, "Id", "Name");
            return View();
        }
        [HttpGet]
        public IActionResult Edit(int id) 
        {
            var product=db.Products.Include(p=>p.Category).FirstOrDefault(p=>p.Id==id);
            if (product == null)
            {
                return RedirectToAction("Index");
            }
            ViewBag.categories = new SelectList(db.Categories, "Id", "Name");
            return View(product);
        }
        [HttpPost]
        public IActionResult Edit(Product product)
        {
            if (product != null)
            {
                db.Products.Update(product);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.categories = new SelectList(db.Categories, "Id", "Name");
            return View();
        }
        [HttpPost]
        public IActionResult Delete(int id) 
        {
            var product = db.Products.Find(id);
            if (product != null) 
            {
                db.Remove(product);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return RedirectToAction("Index");
        }
    }
}
