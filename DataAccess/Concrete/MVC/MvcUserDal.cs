using Core.Entities.Concrete;
using Core.Utilities.Result.Abstract;
using Core.Utilities.Result.Concrete;
using DataAccess.Abstract;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.MVC
{
    public class MvcUserDal : IUserDal
    {
        public Task<Result> AddData(User entity)
        {
            throw new NotImplementedException();
        }

        public Task<Result> DeleteData(User entity)
        {
            throw new NotImplementedException();
        }

        public Task<IDataResult<List<User>>> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task<Result> UpdateData(User entity)
        {
            throw new NotImplementedException();
        }
    }
}
