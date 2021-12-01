using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Demo.Data
{
    public class Author
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        public string? Name { get; set; }

        public virtual ICollection<Book> Books { get; set; } = 
            new List<Book>();

        public virtual ICollection<Magazine> Magazines { get; set; } =
            new List<Magazine>();

        public virtual ICollection<Paper> Papers { get; set; } =
            new List<Paper>();

        public virtual ICollection<Ebook> EBooks { get; set; } =
            new List<Ebook>();
    }
}
