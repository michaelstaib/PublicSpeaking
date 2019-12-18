using System;
using MongoDB.Bson;

namespace Twitter
{
    public class Message
    {
        public ObjectId Id { get; set; }
        public string Text { get; set; }
        public DateTimeOffset Created { get; set; }
        public int Likes { get; set; }
        public ObjectId UserId { get; set; }
        public ObjectId? ReplyToId { get; set; }
    }
}
