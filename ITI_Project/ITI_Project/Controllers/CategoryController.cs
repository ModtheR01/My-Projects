using ITI_Project.Context;
using ITI_Project.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace ITI_Project.Controllers
{
    public class CategoryController : Controller
    {
        MyContext db = new MyContext();

        [HttpGet]
        public IActionResult Index()
        {
            var categories= db.Categories;
            return View(categories);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Category category)
        {
            var existName= db.Categories.FirstOrDefault(c => c.Name==category.Name);
            if (existName != null) 
            {
                ModelState.AddModelError("", "*Category Name Already Exist");
                return View();
            }
            db.Categories.Add(category);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        [HttpGet]
        public IActionResult Details(int id)
        {
            var category = db.Categories.Find(id);
            if (category == null)
            {
                return RedirectToAction("Index");
            }
            return View(category);

        }
        [HttpGet]
        public IActionResult Edit(int id)
        {

            var employee = db.Categories.FirstOrDefault(c=>c.Id==id);
            if (employee == null)
            {
                return RedirectToAction("Index");
            }
            return View(employee);
        }
        /*------------------------------------------------------------------*/
        [HttpPost]
        public IActionResult Edit(Category category)
        {
            
            if (category != null && ModelState.IsValid)
            {
                // Search With Id And Make Update
                db.Categories.Update(category);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
           
            return View(category);
        }
        [HttpPost]
        public IActionResult Delete(int id)
        {
            var category = db.Categories.Find(id);
            if (category == null)
            {
                return RedirectToAction("Index");
            }
            db.Categories.Remove(category);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

    }
}
