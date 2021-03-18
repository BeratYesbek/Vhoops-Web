using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Entities.Concrete
{
    public class Person : IEntity
    {
        public Person(string firstName, string lastName, string email, string password, string userID, string userName)
            : this(firstName, lastName, email, password, userID)
        {
            UserName = userName;
        }
        public Person(string firstName, string lastName, string email, string password, string userID)
        {
            FirstName = firstName;
            LastName = lastName;
            Email = email;
            Password = password;
            UserName = userID;
        }

        public string FirstName { get; }

        public string LastName { get; }

        public string Email { get; }

        public string Password { get; }

        public string UserID { get; }

        public string UserName { get; }
    }
}
