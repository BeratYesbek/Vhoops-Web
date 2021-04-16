using Core.DataAccess.Abstract;
using Core.DataAccess.Abstract.Firebase;
using Core.DataAccess.Concrete;
using Core.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Abstract
{
    public interface IFriendRequestDal : IEntityRepository<FriendRequest>, IFirebaseRequestDal
    {
    }
}
