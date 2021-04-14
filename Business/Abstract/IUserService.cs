using Core.DataAccess.Abstract;
using Core.Entities.Concrete;
using Core.Utilities.Result.Abstract;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IUserService : IServiceRepository<User>
    {
        Task<IResult> UserLogin(User user);
        Task<IResult> CreateUser(User user);
        Task<IResult> UpdateProfileImage(User user);
        Task<IResult> UploadProfileImage(string file);
        Task<IDataResult<string>> GetProfileImage();
        Task<IDataResult<User>> GetByEmail(string email);


    }
}
