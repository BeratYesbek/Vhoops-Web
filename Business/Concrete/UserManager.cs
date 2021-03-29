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
        public Task<IDataResult<User>> GetByUserName(string userName)
        {
            throw new NotImplementedException();
        }
        public async Task<IDataResult<User>> GetByEmail(string email)
        {
            var result =  await _userDal.GetByEmail(email);
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

