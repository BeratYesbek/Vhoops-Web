using Business.Abstract;
using Core.Entities.Concrete;
using Core.Utilities.Result.Abstract;
using DataAccess.Abstract;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class FriendRequestManager : IFriendRequestService
    {
        private IFriendRequestDal _friendRequestDal;
        public FriendRequestManager(IFriendRequestDal friendRequestDal)
        {
            _friendRequestDal = friendRequestDal;
        }
        public Task<IResult> Add(FriendRequest entity)
        {
            return _friendRequestDal.Add(entity);
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
