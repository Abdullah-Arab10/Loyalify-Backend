using Microsoft.AspNetCore.Identity;

namespace Loyalify.Domain.Entities;

public class User : IdentityUser<Guid>
{
    public string FirstName { get; set; } = null!;
    public string LastName { get; set; } = null!;
    public new string Email 
    {
        get => base.Email ?? ""; 
        set => base.Email = value; 
    }
    public string Address { get; set; } = null!;
    public decimal Points { get; set; } = 2000;
    public bool IsActive { get; set; }
}
