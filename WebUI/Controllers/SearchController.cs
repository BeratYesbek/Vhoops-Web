using Business.Concrete;
using DataAccess.Concrete.MVC;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebUI.Controllers
{
    public class SearchController : Controller
    {
        public async Task<IActionResult> Index()
        {
            UserManager userManager = new UserManager(new UserDal());
            var result = userManager.GetAll();
           
            return View(result.Result.Data);
        }

        public async Task<IActionResult> SendFriendRequest()
        {
            return View();
        }
    }
}
