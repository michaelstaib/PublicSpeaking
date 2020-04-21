using System.Collections.Generic;
using HotChocolate.Types;
using HotChocolate.Types.Relay;

namespace StarWars.Characters
{
    /// <summary>
    /// A character in the Star Wars universe.
    /// </summary>
    public abstract class Character
    {
        protected Character(
            int id, 
            string name, 
            IReadOnlyList<int> friends, 
            IReadOnlyList<Episode> appearsIn, 
            double height)
        {
            Id = id;
            Name = name;
            Friends = friends;
            AppearsIn = appearsIn;
            Height = height;
        }

        /// <summary>
        /// The unique identifier for the character.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// The name of the character.
        /// </summary>
        public string Name { get; }

        /// <summary>
        /// The ids of the character's friends.
        /// </summary>
        [UsePaging(SchemaType = typeof(InterfaceType<Character>))]
        public IReadOnlyList<int> Friends { get; }

        /// <summary>
        /// The episodes the character appears in.
        /// </summary>
        public IReadOnlyList<Episode> AppearsIn { get; }

        /// <summary>
        /// The height of the character.
        /// </summary>
        [UseConvertUnit]
        public double Height { get; }
    }
}
