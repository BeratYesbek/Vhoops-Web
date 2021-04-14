using Business.Abstract;
using Business.Constants;
using Business.ValiditionRules.FluentValidation;
using Core.Autofac;
using Core.DataAccess.Abstract;
using Core.Entities.Concrete;
using Core.Entities.FileHelper;
using Core.Utilities.Business;
using Core.Utilities.Result.Abstract;
using Core.Utilities.Result.Concrete;
using DataAccess.Abstract;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.IO;
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
            //userName veri tabanında var mı diye kontrol eder async method olduğunan dolayı Businessrules verilemez

            //first with this method is checked in database whether username exist in there or not
            var userNameResult = CheckUserName(entity.UserName);
            //eğer gelen sonuç true ise demekki veri tabanında kayıt mevuct eğer değilse veri tabanında kayıt mevcut değil
            if (userNameResult.Result.Success)
            {
                return new ErrorResult(userNameResult.Result.Message);
            }
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
            /*  IResult result = BusinessRules.Run(CheckSpecialChar(entity.Password), CheckIfCorrectEmail(entity.Email));
              if (result != null)
              {
                  return result;
              }
              else
              {

              }*/

            var result = await _userDal.Update(entity);
            return result;
        }

        [ValidationAspect(typeof(UserValidator))]
        public Task<IResult> UserLogin(User entity)
        {
            throw new NotImplementedException();
        }


        [ValidationAspect(typeof(UserValidator))]

        public async Task<IResult> CreateUser(User entity)
        {
            var result = await _userDal.CreateUser(entity);

            return result;
        }

        public async Task<IDataResult<List<User>>> GetAll()
        {
            var result = await _userDal.GetAll();
            if (result.Success)
            {
                return new SuccessDataResult<List<User>>();
            }
            else
            {
                return new ErrorDataResult<List<User>>();
            }
        }

        public async Task<IDataResult<User>> GetById(string id)
        {
            var result = await _userDal.GetById(id);
            return result;
        }

        public async Task<IDataResult<string>> GetProfileImage()
        {
            var result = await _userDal.GetProfileImage();
            return result;
        }

        public async Task<IResult> UpdateProfileImage(User manager)
        {
            var result = await _userDal.GetById(manager.UserID);
            if (result.Success)
            {
                return new SuccessDataResult<User>();
            }
            else
            {
                return new ErrorDataResult<User>();
            }
        }

        public async Task<IResult> UploadProfileImage(string file)
        {
            var result = await _userDal.UploadProfileImage(file);
            if (result.Success)
            {
                return new SuccessDataResult<User>();
            }
            else
            {
                return new ErrorDataResult<User>();
            }
        }
        public async Task<IDataResult<User>> GetByUserName(string userName)
        {
            var result = await _userDal.GetByUserName(userName);
            return result;
        }
        public async Task<IDataResult<User>> GetByEmail(string email)
        {
            var result = await _userDal.GetByEmail(email);
            return result;

        }

        /* <---------------  BusinessRules  ---------------> */

        private IResult CheckSpecialChar(string password)
        {
            //in here password must has the least one special character for exmaple ? !
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

        private async Task<IResult> CheckUserName(string userName)
        {
            /* <------ purpose of this method if you added a new user or update user,At database is checked whether username exist in there or not ----->  */
            var result = await _userDal.GetByUserName(userName);
            if (result.Success)
            {
                return new SuccessResult(Messages.UsernameAvailableAlready);
            }
            return new ErrorResult();
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

