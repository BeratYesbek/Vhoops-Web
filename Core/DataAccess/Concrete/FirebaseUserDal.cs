
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
using System.IO;
using System.Threading.Tasks;
using WebUI;

namespace Core.DataAccess.Concrete
{

    public class FirebaseUserDal : IFirebaseUserDal
    {

        public FirebaseUserDal()
        {
            FirebaseConstants.RunFirebase();
        }


        public async Task<IResult> Add(User entity)
        {
            FirestoreDb database = FirestoreDb.Create(FirebaseConstants.DATABASE);

            CollectionReference collection = database.Collection(FirebaseConstants.USER_COLLECTION);
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

        public Task<IResult> Delete(User entity)
        {
            throw new NotImplementedException();

        }

        public async Task<IDataResult<List<User>>> GetAll()
        {
            List<User> userList = new List<User>();

            FirestoreDb database = FirestoreDb.Create(FirebaseConstants.DATABASE);

            Query query = database.Collection(FirebaseConstants.USER_COLLECTION);
            QuerySnapshot userSnapshots = await query.GetSnapshotAsync();

            if (userSnapshots != null)
            {
                foreach (DocumentSnapshot document in userSnapshots.Documents)
                {
                    Dictionary<string, object> data = document.ToDictionary();
                    string documentId = document.Id;
                    string firstName = data["FirstName"].ToString();
                    string lastName = data["LastName"].ToString();
                    string email = data["Email"].ToString();
                    string userID = data["UserID"].ToString();
                    string _userName = data["UserName"].ToString();
                    string about = data["About"].ToString();

                    userList.Add(new User(firstName, lastName, email, "", _userName, userID, null, about,documentId));
                }
                return new SuccessDataResult<List<User>>(userList);
            }
            else
            {
                return new ErrorDataResult<List<User>>();
            }
        }


        public async Task<IResult> Update(User entity)
        {
            FirestoreDb database = FirestoreDb.Create(FirebaseConstants.DATABASE);

            DocumentReference document = database.Collection(FirebaseConstants.USER_COLLECTION).Document(entity.DocumentId);

            Dictionary<string, object> user = new Dictionary<string, object>();
            user.Add("FirstName", entity.FirstName);
            user.Add("LastName", entity.LastName);
            user.Add("UserName", entity.UserName);


            if (entity.ProfileImage != null)
            {
                user.Add("ProfileImage", entity.ProfileImage.ToString());

            }

            await document.UpdateAsync(user);

            return new SuccessResult();

        }

        public async Task<IResult> CreateUser(User entity)
        {
            UserRecordArgs args = new UserRecordArgs()
            {
                Email = entity.Email,
                EmailVerified = false,
                Password = entity.Password,
                DisplayName = entity.FirstName + " " + entity.LastName,
                Disabled = false,
            };
            UserRecord userRecord = await FirebaseAdmin.Auth.FirebaseAuth.DefaultInstance.CreateUserAsync(args);

            if (userRecord != null)
            {
                return new SuccessResult();
            }
            return new ErrorResult();
        }


        public async Task<IDataResult<User>> GetById(string Id)
        {
            FirestoreDb database = FirestoreDb.Create(FirebaseConstants.DATABASE);

            Query userQuery = database.Collection(FirebaseConstants.USER_COLLECTION).WhereEqualTo("UserID", Id);
            QuerySnapshot userSnapshots = await userQuery.GetSnapshotAsync();

            User user = null;
            foreach (DocumentSnapshot document in userSnapshots.Documents)
            {
                Dictionary<string, object> data = document.ToDictionary();
                string documentId = document.Id;
                string firstName = data["FirstName"].ToString();
                string lastName = data["LastName"].ToString();
                string email = data["Email"].ToString();
                string userID = data["UserID"].ToString();
                string userName = data["UserName"].ToString();
                string profileImage = data["ProfileImage"].ToString();
                string token = data["Token"].ToString();
                string about = data["About"].ToString();

                Uri uriImage = null;
                if (profileImage != null)
                {
                    uriImage = new Uri(profileImage);
                }


                user = new User(firstName, lastName, email, "", userName, userID, uriImage, about,documentId);

            }

            if (user != null)
            {
                return new SuccessDataResult<User>(user);
            }
            return new ErrorDataResult<User>();

        }

        public async Task<IResult> UploadProfileImage(string path)
        {

            var file = File.Open(path, FileMode.Open);


            var task = new FirebaseStorage("vhoops-a2dce.appspot.com")
                .Child("UserProfileImage")
                .Child(UserConstants.userId)
                .Child("profileImage")
                .PutAsync(file);

            var downloadUrl = await task;
            if (downloadUrl != null)
            {
                return new SuccessResult();

            }
            return new ErrorResult();


        }


        public async Task<IDataResult<String>> GetProfileImage()
        {
            var task = new FirebaseStorage("vhoops-a2dce.appspot.com")
                .Child("UserProfileImage")
                .Child(UserConstants.userId)
                .Child("profileImage")
                .GetDownloadUrlAsync();

            var downloadUrl = await task;
            if (downloadUrl != null)
            {
                return new SuccessDataResult<String>(downloadUrl);

            }
            return new ErrorDataResult<String>();

        }



        public async Task<IResult> UpdateProfileImage(object profileImage)
        {
            // here is have to change later
            var file = File.Open(@"C:\Users\berat\Pictures\berat.jpg", FileMode.Open);

            var task = new FirebaseStorage("vhoops-a2dce.appspot.com")
                .Child("data")
                .Child("random")
                .Child("file.png")
                .GetDownloadUrlAsync();
            var downloadUrl = await task;
            if (downloadUrl != null)
            {
                return new SuccessResult();

            }
            return new ErrorResult();
        }

        public async Task<IDataResult<User>> GetByUserName(string userName)
        {
            FirestoreDb firestoreDb = FirestoreDb.Create(FirebaseConstants.DATABASE);
            Query userQuery = firestoreDb.Collection(FirebaseConstants.USER_COLLECTION).WhereEqualTo("UserName", userName);
            QuerySnapshot userSnapshots = await userQuery.GetSnapshotAsync();

            User user = null;

            foreach (DocumentSnapshot document in userSnapshots.Documents)
            {
                Dictionary<string, object> data = document.ToDictionary();
                string documentId = document.Id;
                string firstName = data["FirstName"].ToString();
                string lastName = data["LastName"].ToString();
                string email = data["Email"].ToString();
                string userID = data["UserID"].ToString();
                string _userName = data["UserName"].ToString();
                string profileImage = data["ProfileImage"].ToString();
                string token = data["Token"].ToString();
                string about = data["About"].ToString();

                Uri uriImage;
                if (profileImage != null)
                {
                    uriImage = new Uri(profileImage);
                }

                user = new User(firstName, lastName, email, "", _userName, userID, null, about,documentId);

            }
            if (user != null)
            {
                return new SuccessDataResult<User>(user);
            }
            return new ErrorDataResult<User>(user);
        }

        public async Task<IDataResult<User>> GetByEmail(string email)
        {
            FirestoreDb firestoreDb = FirestoreDb.Create(FirebaseConstants.DATABASE);
            Query userQuery = firestoreDb.Collection(FirebaseConstants.USER_COLLECTION).WhereEqualTo("Email", email);
            QuerySnapshot userSnapshots = await userQuery.GetSnapshotAsync();

            User user = null;

            foreach (DocumentSnapshot document in userSnapshots.Documents)
            {
                Dictionary<string, object> data = document.ToDictionary();
                string documentId = document.Id;
                string firstName = data["FirstName"].ToString();
                string lastName = data["LastName"].ToString();
                string _email = data["Email"].ToString();
                string userID = data["UserID"].ToString();
                string userName = data["UserName"].ToString();
                string profileImage = data["ProfileImage"].ToString();
                string token = data["Token"].ToString();
                string about = data["About"].ToString();

                Uri uriImage = null;
                if (profileImage != null)
                {
                    uriImage = new Uri(profileImage);
                }


                user = new User(firstName, lastName, _email, "", userName, userID, uriImage, about,documentId);

            }
            if (user != null)
            {
                return new SuccessDataResult<User>(user);
            }
            return new ErrorDataResult<User>(user);
        }

    }
}
