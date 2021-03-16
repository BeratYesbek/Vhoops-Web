using Core.DataAccess.Abstract;
using Core.Entities.Concrete;
using Core.Utilities.Result.Abstract;
using Core.Utilities.Result.Concrete;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Core.DataAccess.Concrete
{
    public class FirebaseUserDal : IEntityRepository<User>
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

        public Task<Result> CreateUser(User entity)
        {
            throw new NotImplementedException();

        }
        public Task<Result> LoginUser(User entity)
        {
            throw new NotImplementedException();
        }
    }
}
