#pragma warning disable RCS1194
namespace Demo.Types.Errors;

public sealed class UnknownAssetException : Exception
{
    public UnknownAssetException(string symbol)
        : base($"The asset with the symbol `{symbol}` was not found.")
    {
        Symbols = new[] { symbol };
    }

    public UnknownAssetException(string[] symbols)
        : base($"One of the symbols `{string.Join(", ", symbols)}` was not found.")
    {
        Symbols = symbols;
    }

    public IReadOnlyList<string> Symbols { get; }
}
