namespace Demo.Data;

public class Ebook : Publication
{
    [Required]
    public int ReaderId { get; set; }

    public Reader? Reader { get; set; }
}