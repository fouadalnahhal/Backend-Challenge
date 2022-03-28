using Microsoft.AspNetCore.Identity;

namespace CleanArchitecture.Infrastructure.Identity;

public class ApplicationUser : IdentityUser
{
    public Type Type { get; set; }
    public double Salary { get; set; }
}
public enum Type
{
    Administartor,
    Employee
}
