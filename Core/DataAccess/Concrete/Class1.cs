

using Google.Cloud.Firestore;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Core.DataAccess.Concrete
{
    public class Class1
    {
        public void add()
        {
            string path = AppDomain.CurrentDomain.BaseDirectory + @"vhoops-a2dce-firebase-adminsdk-lp79g-566ac754ea.json";
            Environment.SetEnvironmentVariable("GOOGLE_APPLICATION_CREDENTIALS", path);

            FirestoreDb db = FirestoreDb.Create("vhoops-a2dce");

            CollectionReference coll = db.Collection("test5");
            Dictionary<string, object> data1 = new Dictionary<string, object>()
            {
                {"FirstName","tacv" },
                {"LastName","amazing codeverse" },
                {"PhoneNumber",1900232 },
                //array added
                //list added
            };

            ArrayList array = new ArrayList();
            array.Add(123);
            array.Add("name");
            array.Add(true);

            data1.Add("MyArray", array);

            Dictionary<string, object> List1 = new Dictionary<string, object>()
            {
                {"FirstName","tacv" },
                {"LastName","amazing codeverse" },
                {"PhoneNumber",1900232 }
            };

            data1.Add("MyList", List1);

            Console.WriteLine("sadsadsadasdasdsadas");
            coll.AddAsync(data1);
            Console.WriteLine("d56466666s");



        }
    }
}
