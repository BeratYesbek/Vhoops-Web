using Core.Entities.Concrete;
using Core.Utilities.Result.Abstract;
using Core.Utilities.Result.Concrete;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Core.DataAccess.Abstract.Firebase
{

    public interface IFirebaseUserDal : IEntityRepository<User>
    {
        Task<IResult> CreateUser(User entity);

        Task<IResult> LoginUser(User entity);

        Task<IResult> UploadProfileImage(Object profileImage);

        Task<IResult> UpdateProfileImage(Object profileImage);
    }
}
