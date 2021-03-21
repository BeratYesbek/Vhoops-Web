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
    public class RegisterController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Index(User user)
        {


            UserManager usermanager = new UserManager(new UserDal());
            var result = await usermanager.Add(user);

            ViewBag.Result = result.Message;

            return View();
        }
    }
}
