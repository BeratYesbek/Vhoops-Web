using Core.DataAccess.Concrete;
using Core.Utilities.Result;
using Entities;
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

            FirebaseRepository class1 = new FirebaseRepository();
            var data = await class1.GetAll();
            Debug.WriteLine(data.ToString());
            Debug.WriteLine("ömer adam deðil");

        }
    }
}
