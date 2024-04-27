using LibraryManagement.Domain.Common;

namespace LibraryManagement.Domain.Entities;

public sealed class BorrowedBook : BaseDomainEntity
{
    public DateTime BorrowDate { get; set; }
    public DateTime ReturnDate { get; set; }
    public string Status { get; set; }

    // Navigation Properties
    public int MemberID { get; set; }
    public Member Member { get; set; }
    public int BookID { get; set; }
    public Book Book { get; set; }
}
