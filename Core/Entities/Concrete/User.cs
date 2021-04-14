using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Entities.Concrete
{
    public class User : Person, IEntity
    {
        public User(string firstName, string lastName, string email,string password, string userName, string userID,Uri profileImage,string about,string documentId)
            : base(firstName, lastName, email,password, userID, userName)
        {
            ProfileImage = profileImage;
            About = about;
            DocumentId = documentId;
        }

        public User(string firstName, string lastName, string email, string password, string userName):base(firstName, lastName, email, password, userName)
        {

        }
        public User():base() { }

        public Uri ProfileImage { get; set; }
        public String About { get; set; }
        public String DocumentId { get; set; }
    }
}
