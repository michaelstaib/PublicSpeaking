namespace Demo.Data;

[Index(nameof(Name))]
public class User
{
    [Key]
    public int Id { get; set; }

    [Required]
    [MaxLength(25)]
    public string? Name { get; set; }

    public string? DisplayName { get; set; }

    public string? ImageKey { get; set; }
}