

using Business.Concrete;
using Core.Entities.Concrete;
using DataAccess.Concrete.MVC;
using Firebase.Auth;
using Microsoft.AspNetCore.Mvc;
using System;
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
        public async Task<IActionResult> Index(Core.Entities.Concrete.User user)
        {
           
          /*  
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
            }*/
            if(user != null)
            {
                Login(user.Email, user.Password);
            }

            return View();
        }
        
        public async Task Login(string email,string password)

        {
            /*------------------------<<<<<< firebaseAuth service should be used  which included custom user clas >>>>>>>>>------------------,*/


            // That's method is not solid method, but we have a custom user class. we cannot use this method in FirebaseUserDal
            // if  write to FirebaseUserDal it is not seem good,we must cast our user class in FirebaseUserDal for every User, for example Core.Entities.Concrete.User
            // for now we preferred like this
           
            
            try
            {
                var auth = new FirebaseAuthProvider(new FirebaseConfig("AIzaSyAEDDiRGZEpFDLluvE9jpnCw9jLI5UjqmQ"));
                var result = await auth.SignInWithEmailAndPasswordAsync(email,password);
                string token = result.FirebaseToken;
                var user = result.User;
                if(token != null)
                {
                    // user sign in successfully at here you can send 'ChatController' root

                }
                else
                {
                    // user couldn't have sign in successfully

                }

            }
            catch (Exception e)
            {
          

            }
        }
        
    }
}
