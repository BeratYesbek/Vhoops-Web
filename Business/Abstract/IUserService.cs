using Core.DataAccess.Abstract;
using Core.Entities.Concrete;
using Core.Utilities.Result.Abstract;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IUserService : IServiceRepository<User>
    {
        Task<IResult> UserLogin(User user);
        Task<IResult> CreateUser(User user);
        Task<IResult> UpdateProfileImage(User user);
        Task<IResult> UploadProfileImage(User user);
        Task<IDataResult<User>> GetProfileImage(User user);
        Task<IDataResult<User>> GetByEmail(string email);


    }
}
