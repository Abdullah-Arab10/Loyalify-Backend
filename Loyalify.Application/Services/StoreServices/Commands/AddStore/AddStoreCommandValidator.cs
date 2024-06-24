using FluentValidation;
using Loyalify.Application.Services.Store.Commands.AddStore;

namespace Loyalify.Application.Services.StoreServices.Commands.AddStore;

public class AddStoreCommandValidator : AbstractValidator<AddStoreCommand>
{
    public AddStoreCommandValidator()
    {
        RuleFor(x => x.Email).EmailAddress();
        RuleFor(p => p.Password).NotEmpty()
                    .MinimumLength(8)
                    .MaximumLength(16)
                    .Matches(@"[A-Z]+").WithMessage("The password must contain at least one uppercase letter.")
                    .Matches(@"[a-z]+").WithMessage("The password must contain at least one lowercase letter.")
                    .Matches(@"[0-9]+").WithMessage("The password must contain at least one number.")
                    .Matches(@"[\!\?\*\.\;\@\$\#\(\)\^\%\&\-\`]+").WithMessage("The password must contain at least one NonAlphanumeric character");
    }
}
