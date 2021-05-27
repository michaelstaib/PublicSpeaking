using System.Threading;
using System.Threading.Tasks;
using Demo.Data;
using HotChocolate;
using HotChocolate.Subscriptions;
using HotChocolate.Types;

namespace Demo
{
    public class Subscription
    {
        [Subscribe]
        [Topic]
        public Book OnBookReleased([EventMessage] Book book) => book;
    }
}