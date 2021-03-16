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
        Task<IResult> CreateLogin();
        Task<IResult> CreateUser();
    }
}
