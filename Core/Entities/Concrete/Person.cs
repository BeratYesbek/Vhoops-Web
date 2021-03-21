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
        public Person() { }
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Email { get; set; }

        public string Password { get; set; }

        public string UserID { get; set; }

        public string UserName { get; set; }
    }
}
