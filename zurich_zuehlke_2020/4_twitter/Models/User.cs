using MongoDB.Bson;

namespace Twitter
{
    public class User
    {
        public ObjectId Id { get; set; }
        public string Name { get; set; }
        public string Country { get; set; }
    }
}
