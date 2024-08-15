using ErrorOr;

namespace Loyalify.Domain.Common.Errors;

public static partial class Errors
{
    public static class Offer
    {
        public static Error NoOffers => Error.NotFound(
            description: "No available offers");
        public static Error DeactivatedStore => Error.Forbidden(
            description: "This store is deactivated");
        public static Error OfferAlreadyTaken => Error.Forbidden(
            description: "This user already took the offer");
        public static Error OfferExpired => Error.Forbidden(
            description: "Deadline passed");
    }
}
