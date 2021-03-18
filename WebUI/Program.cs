using Business.Concrete;
using Core.DataAccess.Concrete;
using Core.Utilities.Result;
using DataAccess.Concrete.MVC;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace WebUI
{
    public class Program
    {
        public static void Main(string[] args)
        {


            getData();
            CreateHostBuilder(args).Build().Run();

        }

        private static object IGetStringListener()
        {
            throw new NotImplementedException();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });

        public static async Task getData()
        {
/*
            UserManager usermanager = new UserManager(new UserDal());
            usermanager.CreateUser(new Core.Entities.Concrete.User("berat", "yesbek", "omeryavuz@gmail.com", "1223456", "beratybk"));*/

        }
    }
}
