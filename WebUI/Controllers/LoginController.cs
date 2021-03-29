

using Business.Concrete;
using Business.Constants;
using Core.Entities.Concrete;
using Core.Utilities.Result.Abstract;
using Core.Utilities.Result.Concrete;
using DataAccess.Concrete.MVC;
using Firebase.Auth;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace WebUI.Controllers
{
    public class LoginController : Controller
    {
        string user_email;

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Index(Core.Entities.Concrete.User user)
        {

            if (user != null)
            {
                var result = await Login(user.Email, user.Password);
                if (result.Success)
                {
                    TempData["Email"] = user_email;
                    return Redirect("/Chat");

                }
                else
                {
                    ViewBag.Result = result.Success;
                    ViewBag.Message = result.Message;
                    return View();
                }
            
            }
            return View();

        }

        public async Task<IResult> Login(string email, string password)

        {
            /*------------------------<<<<<< firebaseAuth service should be used  which included custom user clas >>>>>>------------------*/


            // That's method is not solid method, but we have a custom user class. we cannot use this method in FirebaseUserDal
            // if  write to FirebaseUserDal it is not seem good,we must cast our user class in FirebaseUserDal for every User, for example Core.Entities.Concrete.User
            // for now we preferred like this


            try
            {
                var auth = new FirebaseAuthProvider(new FirebaseConfig("AIzaSyAEDDiRGZEpFDLluvE9jpnCw9jLI5UjqmQ"));
                var result = await auth.SignInWithEmailAndPasswordAsync(email, password);
                string token = result.FirebaseToken;
                var user = result.User;
                user_email = user.Email;
                if (token != null)
                {
                    return new SuccessResult();
                }
                else
                {
                    return new ErrorResult(Messages.LOGIN_FAILED_MESSAGE);
                }

            }
            catch (Exception e)
            {

            }
            return new ErrorResult(Messages.LOGIN_FAILED_MESSAGE);
        }

    }
}
