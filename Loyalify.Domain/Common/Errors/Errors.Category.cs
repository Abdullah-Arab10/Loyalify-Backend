using ErrorOr;

namespace Loyalify.Domain.Common.Errors;

public static partial class Errors
{
    public static class Category
    {
        public static Error CategoryNotExisted => Error.NotFound(
            description: "Category doesn't exist");
        public static Error CategoryExist => Error.Conflict(
            description: "Category already exist");
        public static Error NoCategories => Error.NotFound(
            description: "There is no Categories");
    }
}
