using Core.Entities.Concrete;
using Core.Utilities.Result.Concrete;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Core.DataAccess.Abstract.Firebase
{

    public interface IFirebaseUserDal : IEntityRepository<User>
    {
        Task<Result> CreateUser(User entity);

        Task<Result> LoginUser(User entity);

        Task<Result> UploadProfileImage(Object profileImage);

        Task<Result> UpdateProfileImage(Object profileImage);
    }
}
