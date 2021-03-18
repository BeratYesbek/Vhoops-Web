using Core.DataAccess.Abstract;
using Core.DataAccess.Abstract.Firebase;
using Core.DataAccess.Constants;
using Core.Entities.Concrete;
using Core.Utilities.Result.Abstract;
using Core.Utilities.Result.Concrete;
using Firebase.Storage;
using FirebaseAdmin.Auth;
using Google.Cloud.Firestore;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Threading.Tasks;

namespace Core.DataAccess.Concrete
{
    public class FirebaseUserDal : IEntityRepository<User>, IFirebaseUserDal
    {

        public FirebaseUserDal()
        {
            FirebaseCollections.RunFirebase();
        }

        public async Task<Result> AddData(User entity)
        {
            FirestoreDb database = FirestoreDb.Create(FirebaseCollections.DATABASE);

            CollectionReference collection = database.Collection(FirebaseCollections.USER_COLLECTION);
            Dictionary<string, object> user = new Dictionary<string, object>
            {

                 { "FirstName", entity.FirstName },
                 { "LastName", entity.LastName },
                 { "Email", entity.Email },

            };
            DocumentReference documentReference = await collection.AddAsync(user);
            if (documentReference != null)
            {
                return new SuccessResult();

            }
            return new ErrorResult();
        }

        public async Task<Result> DeleteData(User entity)
        {
            throw new NotImplementedException();

        }

        public async Task<IDataResult<List<User>>> GetAll()
        {
            throw new NotImplementedException();
        }


        public async Task<Result> UpdateData(User entity)
        {
            FirestoreDb database = FirestoreDb.Create(FirebaseCollections.DATABASE);

            DocumentReference document = database.Collection(FirebaseCollections.USER_COLLECTION).Document(entity.UserID);
            Dictionary<string, object> user = new Dictionary<string, object>
            {
                {"FirstName",entity.FirstName },
                {"LastName",entity.LastName },
                {"UserName",entity.UserName },
                {"ProfileImage",entity.ProfileImage.ToString()}
            };
            await document.UpdateAsync(user);

            return new SuccessResult();

        }

        public async Task<Result> CreateUser(User entity)
        {
            UserRecordArgs args = new UserRecordArgs()
            {
                Email = entity.Email,
                EmailVerified = false,
                Password = entity.Password,
                DisplayName = entity.FirstName + " " + entity.LastName,
                Disabled = false,
            };
            UserRecord userRecord = await FirebaseAuth.DefaultInstance.CreateUserAsync(args);

            if (userRecord != null)
            {
                return new SuccessResult();
            }
            return new ErrorResult();
        }

        public async Task<Result> LoginUser(User entity)
        {
            
            throw new NotImplementedException();
        }



        public async Task<IDataResult<List<User>>> GetById(string Id)
        {
            FirestoreDb database = FirestoreDb.Create(FirebaseCollections.DATABASE);

            Query userQuery = database.Collection(FirebaseCollections.USER_COLLECTION).WhereEqualTo("UserID", Id);
            QuerySnapshot userSnapshots = await userQuery.GetSnapshotAsync();

            List<User> userList = new List<User>();
            foreach (DocumentSnapshot document in userSnapshots.Documents)
            {
                Dictionary<string, object> data = document.ToDictionary();

                string firstName = data["FirstName"].ToString();
                string lastName = data["LastName"].ToString();
                string email = data["Email"].ToString();
                string userID = data["UserID"].ToString();

                userList.Add(new User(firstName, lastName, email, "", ""));

            }

            if (userList.Count > 0)
            {
                return new SuccessDataResult<List<User>>(userList);
            }
            return new ErrorDataResult<List<User>>();

        }

        public async Task<Result> UploadProfileImage(object profileImage)
        {

            var file = File.Open(@"C:\Users\berat\Pictures\berat.jpg", FileMode.Open);
           
            
            // here is have to change later
            var task = new FirebaseStorage("vhoops-a2dce.appspot.com")
                .Child("data")
                .Child("random")
                .Child("file.png")
                .PutAsync(file);

            var downloadUrl = await task;
            if (downloadUrl != null)
            {
                return new SuccessResult();

            }
            return new ErrorResult();


        }

        public async Task<Result> UpdateProfileImage(object profileImage)
        {
            // here is have to change later
            var file = File.Open(@"C:\Users\berat\Pictures\berat.jpg", FileMode.Open);

            var task = new FirebaseStorage("vhoops-a2dce.appspot.com")
                .Child("userProfile")
                .Child("userid")
                .Child("file.png")
                .GetDownloadUrlAsync();
            var downloadUrl = await task;
            if (downloadUrl != null)
            {
                return new SuccessResult();

            }
            return new ErrorResult();
        }
    }
}
