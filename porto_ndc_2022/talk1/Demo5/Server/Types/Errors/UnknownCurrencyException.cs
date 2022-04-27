#pragma warning disable RCS1194
namespace Demo.Types.Errors;

public sealed class UnknownCurrencyException : Exception
{
    public UnknownCurrencyException(string currency)
        : base("The specified currency is not known to the system.")
    {
        Currency = currency;
    }

    public string Currency { get; }
}
