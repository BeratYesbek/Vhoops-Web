using Business.Concrete;
using Core.Entities.Concrete;
using DataAccess.Concrete.MVC;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebUI.Controllers
{
    public class LoginController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Index(User user)
        {

            UserManager usermanager = new UserManager(new UserDal());
            var result = await usermanager.UserLogin(user);
            if (result.Success)
            {
                var userLoginResult = await usermanager.UserLogin(user);
                ViewBag.Result = userLoginResult.Success;
                ViewBag.Message = userLoginResult.Message;
                Console.WriteLine("Success");
            }
            else
            {
                ViewBag.Result = result.Success;
                ViewBag.Message = result.Message;
            }

            return View();
        }
    }
}
