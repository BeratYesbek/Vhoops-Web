using Business.Concrete;
using Core.Entities.Concrete;
using DataAccess.Concrete;
using DataAccess.Concrete.MVC;
using Google.Cloud.Firestore;
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

        public async Task<IActionResult> SendFriendRequest(string receiverId)
        {
            var now = Timestamp.GetCurrentTimestamp();

            FriendRequestManager friendRequest = new FriendRequestManager(new FriendRequestDal());
            var result = await friendRequest.Add(new FriendRequest(UserConstants.userId, receiverId, now, false));

            if (result.Success)
            {
                ViewBag.Result = result.Success;
                return View("Index",ViewBag);
            }
            return View("Index",ViewBag);
        }
    }
}
