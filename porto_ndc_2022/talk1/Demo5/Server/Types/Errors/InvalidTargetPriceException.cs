#pragma warning disable RCS1194
namespace Demo.Types.Errors;

public sealed class InvalidTargetPriceException : Exception
{
    public InvalidTargetPriceException(double targetPrice)
        : base("The target price must be greater than 0.")
    {
        TargetPrice = targetPrice;
    }

    public double TargetPrice { get; }
}
