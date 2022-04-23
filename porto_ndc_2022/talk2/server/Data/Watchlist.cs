using System.ComponentModel;

namespace Demo.Data;

[Index(nameof(User), IsUnique = true)]
public class Watchlist
{
    [Key]
    public int Id { get; set; }

    [Required]
    [MaxLength(28)]
    public string? User { get; set; }

    [EditorBrowsable(EditorBrowsableState.Never)]
    public string? SymbolsData { get; set; }

    internal List<string> GetSymbols()
        => SymbolsData is null
            ? new()
            : SymbolsData.Split(',').ToList();

    internal void SetSymbols(IReadOnlyList<string> symbols)
        => SymbolsData = symbols.Count == 0
            ? null
            : string.Join(",", symbols.Distinct());

    internal void AddSymbols(params string[] symbols)
    {
        var data = GetSymbols();
        data.AddRange(symbols);
        SetSymbols(data);
    }

    internal void RemoveSymbols(params string[] symbols)
    {
        var data = GetSymbols();
        foreach (string symbol in symbols)
        {
            data.Remove(symbol);
        }
        SetSymbols(data);
    }
}