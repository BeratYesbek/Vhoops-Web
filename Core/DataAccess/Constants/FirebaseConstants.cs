using System;
using System.Collections.Generic;
using Google.Apis.Services;
using Google.Apis.Auth.OAuth2;
using System.IO;
using Google.Apis.Sheets.v4;
using Google.Apis.Sheets.v4.Data;
using Grpc.Core;
using Google.Cloud.Firestore;
using FirebaseAdmin;
using System.Threading.Tasks;

namespace Core.DataAccess.Constants
{
    //That's static class can keep properties of firebase
    public static class FirebaseConstants
    {


        public static string USER_COLLECTION = "Users";
        public static string CHAT_COLLECTION = "Chats";

        public static string DATABASE = "vhoops-a2dce";
        public static string STORAGE_PATH = "vhoops-a2dce.appspot.com";

        
        public static void RunFirebase()
        {
            try
            {
                // here is working to cloud firebase
                string path = AppDomain.CurrentDomain.BaseDirectory + @"vhoops-a2dce-firebase-adminsdk-lp79g-52f9a01b70.json";

                FirebaseApp.Create(new AppOptions()
                {
                    Credential = GoogleCredential.FromFile(path)
                });
                Environment.SetEnvironmentVariable("GOOGLE_APPLICATION_CREDENTIALS", path);


            }
            catch (Exception e)
            {

            }
        }

    }

}


/*
            //that's not necessary now
            FirebaseApp.Create(new AppOptions()
            {
                Credential = GoogleCredential.FromFile("C:/Users/berat/source/repos/Vhoops_netCore/Core/vhoops-a2dce-firebase-adminsdk-lp79g-52f9a01b70.json"),
            });

            */
