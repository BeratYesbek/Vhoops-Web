using Business.Concrete;
using Core.Entities.Concrete;
using Core.Entities.FileHelper;
using Core.Utilities.Result.Abstract;
using Core.Utilities.Result.Concrete;
using DataAccess.Concrete.MVC;
using Grpc.Core;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace WebUI.Controllers
{
    public class UpdatePageController : Controller
    {
        private IHostingEnvironment _env;
        public UpdatePageController(IHostingEnvironment env)
        {
            _env = env;
        }
        public async Task<IActionResult> Index()
        {
            UserManager userManager = new UserManager(new UserDal());
            var result = await userManager.GetById(UserConstants.userId);
            if (result.Success)
            {

                return View(result.Data);

            }
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Index(User user, IFormFile file)
        {

            if (file != null)
            {
                await UpdateData(file, user);
            }
            else
            {
                UserManager userManager = new UserManager(new UserDal());
                user.DocumentId = UserConstants.userDocumentId;
                var result = await userManager.Update(user);
            }


            return View();

        }


        public async Task<IResult> UpdateData(IFormFile file, User user)
        {
            var pathUpload = FileHelper.Upload(file);

            string pathh = Path.Combine(_env.WebRootPath);
            string realPath = pathh + pathUpload.Message;

            UserManager userManager = new UserManager(new UserDal());
            var result = await userManager.UploadProfileImage(realPath);

            var url = await userManager.GetProfileImage();
            Uri uri = new Uri(url.Message);
            user.ProfileImage = uri;
            user.DocumentId = UserConstants.userDocumentId;

            var updateResult = userManager.Update(user);

            if (updateResult.Result.Success)
            {
                return new SuccessResult();
            }
            return new ErrorResult();

        }

    }
}
