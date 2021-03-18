using Core.DataAccess.Abstract;
using Core.DataAccess.Abstract.Firebase;
using Core.Entities.Concrete;
using Core.Utilities.Result.Abstract;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Abstract
{
    //IUserDal can access to methods of IFirebaseUserDal 
    //if you wanna change your database, you should change your impelemention  
    public interface IUserDal : IEntityRepository<User>, IFirebaseUserDal
    {

    }
}
