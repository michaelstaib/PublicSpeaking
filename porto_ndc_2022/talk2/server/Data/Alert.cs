namespace Demo.Data;

[Index(nameof(AssetId))]
[Index(nameof(AssetId), nameof(Username))]
public class Alert
{
    [Key]
    public int Id { get; set; }

    [Required]
    [MaxLength(25)]
    public string? Username { get; set; }

    public double PercentageChange { get; set; }

    [Required]
    [MaxLength(5)]
    public string? Currency { get; set; }

    public double TargetPrice { get; set; }

    public bool Recurring { get; set; } = true;

    [Required]
    public int AssetId { get; set; }

    public Asset? Asset { get; set; }
}
