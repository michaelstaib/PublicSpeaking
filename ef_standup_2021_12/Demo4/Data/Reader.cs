namespace Demo.Data;

public class Reader
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }

    [Required]
    public string? Name { get; set; }

    public virtual ICollection<Ebook> EBooks { get; set; } =
        new List<Ebook>();
}