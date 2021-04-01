using Business.Concrete;
using DataAccess.Concrete.MVC;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebUI.ViewComponents
{
    public class UpdateViewComponent : ViewComponent
    {

        public IViewComponentResult Invoke()
        {
            UserManager userManager = new UserManager(new UserDal());
            return View();
        }
    }
}
