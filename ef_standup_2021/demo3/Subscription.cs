using System;
using System.Linq;
using System.Threading;
using Demo.Data;
using HotChocolate;
using HotChocolate.Data;
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