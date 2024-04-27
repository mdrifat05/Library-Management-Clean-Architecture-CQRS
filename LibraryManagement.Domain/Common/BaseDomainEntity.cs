namespace LibraryManagement.Domain.Common;

public abstract class BaseDomainEntity
{
    public int ID { get; init; }
    public DateTime CreateDate { get; set; }
    public string CreatedBy { get; set; }
    public DateTime LastModifiedDate { get; set; }
    public string LastModifiedBy { get; set; }
}
