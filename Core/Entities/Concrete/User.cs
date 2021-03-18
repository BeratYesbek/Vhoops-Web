using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Entities.Concrete
{
    public class User : Person, IEntity
    {
        public User(string firstName, string lastName, string email,string password, string userName, string userID,Uri profileImage)
            : base(firstName, lastName, email,password, userName, userID)
        {
            ProfileImage = profileImage;
        }

        public User(string firstName, string lastName, string email, string password, string userName):base(firstName, lastName, email, password, userName)
        {

        }

        public Uri ProfileImage { get;}
    }
}
