namespace Demo
{
    public class Person
    {
        public Person(string name, string? city = null)
        {
            Name = name;
            City = city;
        }

        public string Name { get; }

        public string? City { get; }
    }
}
