using LibraryManagement.Domain.Common;

namespace LibraryManagement.Domain.Entities;

public sealed class Member : BaseDomainEntity
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Email { get; set; }
    public string PhoneNumber { get; set; }
    public DateTime RegistrationDate { get; set; }
}
