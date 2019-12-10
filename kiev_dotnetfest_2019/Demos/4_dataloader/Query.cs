using System.Linq;

namespace HotChocolate.Examples.Paging
{
    public class Query
    {
        public IQueryable<Message> GetMessages([Service]MessageRepository repository)
        {
            return repository.GetAllMessages();
        }
    }
}
