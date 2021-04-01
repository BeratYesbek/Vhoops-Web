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
        User _user;
        public async Task<IActionResult> Index()
        {
            var email = TempData["Email"];
            UserManager userManager = new UserManager(new UserDal());
            var result = await userManager.GetByEmail(email.ToString());
            _user = result.Data;
            ViewBag.Image = _user.ProfileImage;
            return View();
        }
        
    }
}

