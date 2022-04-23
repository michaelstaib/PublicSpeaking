namespace Demo.Types.Account;

public record UpdateUserProfileInput(Optional<string?> DisplayName, Optional<IFile?> Image);