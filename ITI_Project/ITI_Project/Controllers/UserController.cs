using ITI_Project.Context;
using ITI_Project.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace ITI_Project.Controllers
{
    public class UserController : Controller
    {
        MyContext db=new MyContext();

        [HttpGet]
        public IActionResult Regiester()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Regiester(User user)
        {
            var existEmail=db.Users.FirstOrDefault(x => x.Email==user.Email);
            if (existEmail == null)
            {
                db.Users.Add(user);
                db.SaveChanges();
                return RedirectToAction("Login");
            }
            ModelState.AddModelError("", "*This Email Is Exist");
            return View();
        }
        [HttpGet]
        public IActionResult Login() 
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(User user)
        {
            var userLogin = db.Users.FirstOrDefault(e=>e.Email == user.Email && e.Password == user.Password);
            if (userLogin !=  null )
            {
                return RedirectToAction("Index","Product");
            }
            ModelState.AddModelError("","*Your Email or Password Not Correct");
            return View();
        }


    }
}
