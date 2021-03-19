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
        Task<IResult> UserLogin(User manager);
        Task<IResult> CreateUser(User manager);
        Task<IResult> UpdateProfileImage(User manager);
        Task<IResult> UploadProfileImage(User manager);
        Task<IDataResult<User>> GetProfileImage(User manager);
    }
}
