using ErrorOr;

namespace Loyalify.Domain.Common.Errors;

public static partial class Errors
{
    public static class User
    {
        public static Error DuplicateEmail => Error.Conflict(
            description: "Email is already in use");
    }
}
