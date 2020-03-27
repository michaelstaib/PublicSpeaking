using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using GreenDonut;

namespace Chat.Server.People
{
    public class PersonByIdDataLoader
        : DataLoaderBase<Guid, Person>
    {
        private readonly IPersonRepository _repository;

        public PersonByIdDataLoader(IPersonRepository repository)
        {
            _repository = repository;
        }

        protected override async Task<IReadOnlyList<Result<Person>>> FetchAsync(
            IReadOnlyList<Guid> keys,
            CancellationToken cancellationToken)
        {
            IReadOnlyDictionary<Guid, Person> result =
                await _repository.GetPeopleAsync(
                    keys, cancellationToken)
                    .ConfigureAwait(false);

            var persons = new Result<Person>[keys.Count];

            for (int i = 0; i < keys.Count; i++)
            {
                if (result.TryGetValue(keys[i], out Person? person))
                {
                    persons[i] = person;
                }
            }

            return persons;
        }
    }
}