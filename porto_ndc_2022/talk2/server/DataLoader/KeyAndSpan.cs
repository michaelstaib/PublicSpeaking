using Demo.Types.Assets;

namespace Demo.DataLoader;

public readonly record struct KeyAndSpan(string Symbol, ChangeSpan Span);