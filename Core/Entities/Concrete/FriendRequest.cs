using Google.Cloud.Firestore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Entities.Concrete
{
    public class FriendRequest : IEntity
    {
        public string DocumentId { get; set; }
        public string SenderId { get; set; }
        public string ReceiverId { get; set; }
        public Timestamp TimeToSend { get; set; }
        public bool Status { get; set; }

    }
}
