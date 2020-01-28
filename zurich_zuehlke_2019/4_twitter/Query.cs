
using System.Linq;
using System.Reflection;
using System.Threading;
using System.Threading.Tasks;
using HotChocolate;
using HotChocolate.AspNetCore.Authorization;
using HotChocolate.Types;
using HotChocolate.Types.Descriptors;
using HotChocolate.Types.Relay;

namespace Twitter
{
    public class Query
    {
        [UsePaging]
        [UseFiltering]
        [UseSorting]
        public IQueryable<User> GetAllUsers(
            [Service]UserRepository repository) =>
            repository.GetAllUsers();
    }

    public class Mutation
    {
        public async Task<User> CreateUserAsync(
            UserInput input,
            [Service]UserRepository repository,
            CancellationToken cancellationToken)
        {
            var user = new User
            {
                Name = input.Name,
                Country = input.Country
            };

            await repository.CreateUserAsync(user, cancellationToken);

            return user;
        }


        public class UserInput
        {
            public string Name { get; set; }

            [DefaultValue(Value = "CH")]
            public string Country { get; set; }
        }

        public class DefaultValueAttribute : InputFieldDescriptorAttribute
        {
            public string? Value { get; set;}

            public override void OnConfigure(
                IDescriptorContext context, 
                IInputFieldDescriptor descriptor, 
                MemberInfo member)
            {
                descriptor.DefaultValue(Value);
            }
        }
    }
}