namespace Demo.Types.Notifications;

public sealed record CreateAlertInput(
    string Symbol,
    double TargetPrice,
    [property: DefaultValue("USD")] string Currency,
    [property: DefaultValue(false)] bool Recurring);