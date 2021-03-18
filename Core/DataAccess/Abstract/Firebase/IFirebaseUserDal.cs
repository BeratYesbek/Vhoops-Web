using Core.Utilities.Result.Concrete;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Core.DataAccess.Abstract.Firebase
{
    public interface IFirebaseUserDal
    {

        Task<Result> UploadProfileImage(Object profileImage);

        Task<Result> UpdateProfileImage(Object profileImage);
    }
}
