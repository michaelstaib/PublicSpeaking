using HotChocolate;
using HotChocolate.Subscriptions;

namespace Demo
{
    public class Mutation
    {
        public Person AddPerson(
            Person person,
            [Service]IEventDispatcher eventDispatcher)
        {
            eventDispatcher.SendAsync("new", person);
            return person;
        }
    }
}
