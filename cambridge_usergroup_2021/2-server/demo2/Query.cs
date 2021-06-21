using System.Linq;
using Demo.Data;
using HotChocolate;
using HotChocolate.Data;
using HotChocolate.Types;

namespace Demo
{
    public class Query 
    {
        public Book GetBook() => new Book { Title = "C# in Depth", Author = new Author { Name = "Jon Skeet" } };
    }
}
