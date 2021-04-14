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
            if (!UserConstants.control)
            {
                UserConstants.userEmail = TempData["Email"].ToString();
                UserConstants.control = true;
                UserManager userManager = new UserManager(new UserDal());
                var result = await userManager.GetByEmail(UserConstants.userEmail);
                UserConstants.userDocumentId = result.Data.DocumentId;
                _user = result.Data;
                ViewBag.Image = _user.ProfileImage;

            }
          
         
            return View();
        }
        
    }
}

