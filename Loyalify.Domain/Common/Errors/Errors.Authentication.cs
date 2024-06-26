﻿using ErrorOr;

namespace Loyalify.Domain.Common.Errors;

public static partial class Errors
{
    public static class Authentication
    {
        public static Error InvalidCredentials => Error.Validation(
            description: "Invalid Credentials.");
        public static Error DeactivatedEmail => Error.Forbidden(
            description: "This email is deactivated");
    }
}
