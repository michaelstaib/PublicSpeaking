using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using GreenDonut;

namespace Chat.Server.People
{
    public class PersonByEmailDataLoader
        : DataLoaderBase<string, Person>
    {
        private readonly IPersonRepository _repository;

        public PersonByEmailDataLoader(IPersonRepository repository)
        {
            _repository = repository;
        }

        protected override async Task<IReadOnlyList<Result<Person>>> FetchAsync(
            IReadOnlyList<string> keys,
            CancellationToken cancellationToken)
        {
            IReadOnlyDictionary<string, Person> result =
                await _repository.GetPeopleByEmailAsync(
                    keys, cancellationToken)
                    .ConfigureAwait(false);

            var users = new Result<Person>[keys.Count];

            for (int i = 0; i < keys.Count; i++)
            {
                if (result.TryGetValue(keys[i], out Person? person))
                {
                    users[i] = person;
                }
            }

            return users;
        }
    }
}