namespace Demo.Data;

[Index(nameof(Username))]
public class Notification
{
    [Key]
    public int Id { get; set; }

    [Required]
    [MaxLength(5)]
    public string? Symbol { get; set; }

    [Required]
    [MaxLength(25)]
    public string? Username { get; set; }

    public string? Message { get; set; }

    public bool Read { get; set; }
}