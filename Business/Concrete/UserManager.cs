using Business.Abstract;
using Business.Constants;
using Business.ValiditionRules.FluentValidation;
using Core.Autofac;
using Core.DataAccess.Abstract;
using Core.Entities.Concrete;
using Core.Utilities.Business;
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

        [ValidationAspect(typeof(UserValidator))]
        public async Task<IResult> Add(User entity)
        {

            IResult result = BusinessRules.Run(CheckSpecialChar(entity.Password), CheckIfCorrectEmail(entity.Email));
            if (result != null)
            {
                return result;
            }
            else
            {
                await _userDal.Add(entity);
                return new SuccessResult();
            }

        }

        [ValidationAspect(typeof(UserValidator))]
        public Task<IResult> Delete(User entity)
        {
            throw new NotImplementedException();
        }

        [ValidationAspect(typeof(UserValidator))]
        public async Task<IResult> Update(User entity)
        {
            IResult result = BusinessRules.Run(CheckSpecialChar(entity.Password), CheckIfCorrectEmail(entity.Email));
            if (result != null)
            {
                return result;
            }
            else
            {
                await _userDal.Update(entity);
                return new SuccessResult();
            }
        }

        [ValidationAspect(typeof(UserValidator))]
        public async Task<IResult> UserLogin(User entity)
        {
            await _userDal.LoginUser(entity);
            return new SuccessResult();
        }

        [ValidationAspect(typeof(UserValidator))]
        public async Task<IResult> CreateUser(User entity)
        {
            await _userDal.CreateUser(entity);

            return new SuccessResult();
        }

        public async Task<IDataResult<List<User>>> GetAll()
        {
            await _userDal.GetAll();
            return new SuccessDataResult<List<User>>();
        }

        public async Task<IDataResult<User>> GetById(string id)
        {
            await _userDal.GetById(id);
            return new SuccessDataResult<User>();
        }

        public async Task<IDataResult<User>> GetProfileImage(User manager)
        {
            await _userDal.GetById(manager.UserID);
            return new SuccessDataResult<User>();
        }

        public async Task<IResult> UpdateProfileImage(User manager)
        {
            await _userDal.GetById(manager.UserID);
            return new SuccessDataResult<User>();
        }

        public async Task<IResult> UploadProfileImage(User manager)
        {
            await _userDal.GetById(manager.UserID);
            return new SuccessDataResult<User>();
        }



        //<---------------  BusinessRules  --------------->

        private IResult CheckSpecialChar(string password)
        {
            Regex passwordSymbol = new Regex(@"[^a-zA-Z0-9]");
            if (!passwordSymbol.IsMatch(password))
            {
                return new ErrorResult(Messages.CheckSpecialChar);
            }
            else
            {
                return new SuccessResult();
            }
        }

        private IResult CheckIfCorrectEmail(string email)
        {
            var isEmail = @"\A(?:[a-z0-9!#$%&'*+/=?^_`{|}~-]+(?:\.[a-z0-9!#$%&'*+/=?^_`{|}~-]+)*@(?:[a-z0-9](?:[a-z0-9-]*[a-z0-9])?\.)+[a-z0-9](?:[a-z0-9-]*[a-z0-9])?)\Z";
            Regex passwordSymbol = new Regex(isEmail);
            if (!passwordSymbol.IsMatch(email))
            {
                return new ErrorResult(Messages.CheckIfCorrectEmail);
            }
            else
            {
                return new SuccessResult();
            }

        }

    }
}

