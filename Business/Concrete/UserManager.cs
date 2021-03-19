using Business.Abstract;
using Business.Constants;
using Core.Autofac;
using Core.DataAccess.Abstract;
using Core.Entities.Concrete;
using Core.Utilities.Result.Abstract;
using Core.Utilities.Result.Concrete;
using DataAccess.Abstract;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class UserManager : IUserService
    {

        IUserDal _userDal;
        public UserManager(IUserDal userDal)
        {
            _userDal = userDal;
        }

        //    [ValidationAspect(typeof(UserValidator))]
        public async Task<Result> Add(User entity)
        {
            var result = await _userDal.Add(entity);
            return new SuccessResult();

        }

        public Task<IResult> UserLogin(User entity)
        {
            throw new NotImplementedException();
        }

        public async Task<IResult> CreateUser(User entity)
        {
           await _userDal.CreateUser(entity);

            return new SuccessResult();
        }

        public Task<Result> Delete(User entity)
        {
            throw new NotImplementedException();
        }

        public Task<IDataResult<List<User>>> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task<IDataResult<User>> GetById(string id)
        {
            throw new NotImplementedException();
        }

        public Task<IDataResult<User>> GetProfileImage(User manager)
        {
            throw new NotImplementedException();
        }

        public Task<Result> Update(User entity)
        {
            throw new NotImplementedException();
        }

        public Task<IResult> UpdateProfileImage(User manager)
        {
            throw new NotImplementedException();
        }

        public Task<IResult> UploadProfileImage(User manager)
        {
            throw new NotImplementedException();
        }



        //<---------------  BusinessRules  --------------->


    }
}

/*    private IResult CheckSpecialChar(string password)
        {
            Regex passwordSymbol = new Regex("[^a-zA-Z0-9]");
            if (!passwordSymbol.IsMatch(password))
            {
                return new  ErrorResult(Messages.CheckSpecialChar);
            }
            else
            {
                return new SuccessResult();
            }
        }*/