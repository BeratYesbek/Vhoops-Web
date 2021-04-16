using Core.DataAccess.Abstract.Firebase;
using Core.DataAccess.Constants;
using Core.Entities.Concrete;
using Core.Utilities.Result.Abstract;
using Core.Utilities.Result.Concrete;
using Google.Cloud.Firestore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Core.DataAccess.Concrete
{
    public class FirebaseFriendRequestDal : IFirebaseRequestDal
    {
        public async Task<IResult> Add(FriendRequest entity)
        {
            FirestoreDb database = FirestoreDb.Create(FirebaseConstants.DATABASE);

            CollectionReference collectionReference = database.Collection(FirebaseConstants.FRIEND_REQUEST_COLLECTION);

            Dictionary<string, object> keys = new Dictionary<string, object>
            {
                {"ReceiverId", entity.ReceiverId},
                {"SenderId", entity.SenderId},
                {"TimeStamp", entity.TimeToSend},
                {"Status", entity.Status},
            };

            DocumentReference document = await collectionReference.AddAsync(keys);
            if (document != null)
            {
                return new SuccessResult();
            }

            return new ErrorResult();

        }

        public Task<IResult> Delete(FriendRequest entity)
        {
            throw new NotImplementedException();
        }

        public Task<IDataResult<List<FriendRequest>>> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task<IDataResult<FriendRequest>> GetById(string id)
        {
            throw new NotImplementedException();
        }

        public Task<IResult> Update(FriendRequest entity)
        {
            throw new NotImplementedException();
        }
    }
}
