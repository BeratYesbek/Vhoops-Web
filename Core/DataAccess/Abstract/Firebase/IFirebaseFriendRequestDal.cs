using Core.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.DataAccess.Abstract.Firebase
{
    public interface IFirebaseRequestDal : IEntityRepository<FriendRequest>
    {
    }
}
