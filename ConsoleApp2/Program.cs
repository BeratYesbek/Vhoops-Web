using Core.DataAccess.Concrete;
using System;

namespace ConsoleApp2
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            Class1 class1 = new Class1();
            class1.getDataAsync();
        }
        
    }
}
