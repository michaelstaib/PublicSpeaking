using System.Collections.Generic;
using HotChocolate.Types;
using HotChocolate.Types.Relay;

namespace Demo
{
    public class Query
    {
        [UsePaging]
        [UseFiltering]
        [UseSorting]
        public IEnumerable<Person> GetPersons() =>
            new[] {
                new Person("Jose", "Zurich"),
                new Person("Michael")
            };
    }
}
