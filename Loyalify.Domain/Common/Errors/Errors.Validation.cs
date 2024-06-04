using ErrorOr;

namespace Loyalify.Domain.Common.Errors;

public partial class Errors
{
    public static class Validation
    {
        public static Error IdentityError(List<string> errors) => Error.Validation(
            description: string.Join(",", errors));
    }
}
