using Business.Concrete;
using Core.Entities.Concrete;
using DataAccess.Abstract;
using DataAccess.Concrete.MVC;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebUI.Controllers
{
  

    public class ChatController : Controller
    {
        public async Task<IActionResult>  Index()
        {
            var email = TempData["Email"];
            UserManager userManager = new UserManager(new UserDal());
            var result = await userManager.GetByEmail(email.ToString());
            User user = result.Data;
            ViewBag.Image = user.ProfileImage;
            return View();
        }

        public IActionResult ChatPage()
        {
            return View();
        }
    }
}
