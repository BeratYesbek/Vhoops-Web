using Business.Constants;
using Core.Entities.Concrete;
using Core.Utilities.Result.Abstract;
using Core.Utilities.Result.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Business.ValiditionRules.FluentValidation
{
    public class UserValidator : AbstractValidator<User>
    {
        public UserValidator()
        {
            RuleFor(u => u.FirstName).NotEmpty().Must(CheckIfJustLetters).WithMessage(Messages.CheckIfJustLetters);
            RuleFor(u => u.LastName).NotEmpty().Must(CheckIfJustLetters).WithMessage(Messages.CheckIfJustLetters);
            RuleFor(u => u.UserName).NotEmpty().Must(CheckIfCharacter).WithMessage(Messages.InUsernameCheckIfCharachter);
            RuleFor(u => u.Password).NotEmpty();
            RuleFor(u => u.Email).NotEmpty();

            RuleFor(u => u.FirstName).MinimumLength(2);
            RuleFor(u => u.LastName).MinimumLength(2);
            RuleFor(u => u.Password).MinimumLength(8).WithMessage(Messages.MaxLength); ;

            RuleFor(u => u.FirstName).MaximumLength(18).WithMessage(Messages.MaxLength);
            RuleFor(u => u.LastName).MaximumLength(18).WithMessage(Messages.MaxLength);
            RuleFor(u => u.Password).MaximumLength(18).WithMessage(Messages.MaxLength);
            RuleFor(u => u.UserName).MaximumLength(12).WithMessage(Messages.InUsernameCheckIfCharachter);
            //RuleFor(u => u.Password).Must(CheckSpecialChar).WithMessage("Şifreniz en az bir özel karakter içermelidir.");


        }

        //private bool CheckSpecialChar(string arg)
        //{
        //    Regex passwordSymbol = new Regex("[^a-zA-Z0-9]");
        //    if (!passwordSymbol.IsMatch(arg))
        //    {
        //        return false;
        //    }
        //    else
        //    {
        //        return true;
        //    }
        //}

        private bool CheckIfJustLetters(string name)
        {
            Regex nameSymbol = new Regex(@"^[a-zA-Z]*$");
            if (!nameSymbol.IsMatch(name))
            {
                return false;
            }
            else
            {
                return true;
            }

        }
        private bool CheckIfCharacter(string username)
        {
            /* <-------- username must not be content any special character --------> */
            Regex usernameCheck = new Regex(@"^(?=[a-zA-Z0-9._]{8,20}$)(?!.*[_.]{2})[^_.].*[^_.]$");
            if (!usernameCheck.IsMatch(username))
            {
                return false;
            }
            else
            {
                return true;
            }

        }
    }
}
