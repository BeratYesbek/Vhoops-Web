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

        /*<<<<---------Database Collection----------->>>>*/
        public static string USER_COLLECTION = "Users";
        public static string CHAT_COLLECTION = "Chats";
        public static string FRIEND_REQUEST_COLLECTION = "FriendRequests";
        /*<<<<<------------Database properties-------->>>>>*/
        public static string DATABASE = "vhoops-test-project";
        public static string STORAGE_PATH = "vhoops-test-project.appspot.com";
         public static string API_URL = "AIzaSyAa4gEa8XFwfGVFSsIsxY7HmjVTzTlPmw8";


        public static void RunFirebase()
        {
            try
            {
                //  working cloud firebase and firebaseAuth
                string path = AppDomain.CurrentDomain.BaseDirectory + @"vhoops-test-project-firebase-adminsdk-yhzj9-76b11a2217.json";


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


