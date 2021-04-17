using Google.Cloud.Firestore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Entities.Concrete
{
    public class FriendRequest : IEntity
    {
        public FriendRequest(string senderId, string receiverId, Timestamp timeToSend, bool status, string documentId) : this(senderId, receiverId, timeToSend, status)
        {
            DocumentId = documentId;
        }
        public FriendRequest(string senderId, string receiverId, Timestamp timeToSend, bool status)
        {
            SenderId = senderId;
            ReceiverId = receiverId;
            TimeToSend = timeToSend;
            Status = status;
        }

        public string DocumentId { get; set; }
        public string SenderId { get; set; }
        public string ReceiverId { get; set; }
        public Timestamp TimeToSend { get; set; }
        public bool Status { get; set; }

    }
}
