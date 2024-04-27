namespace LibraryManagement.Application.Contracts.Persistence;

public interface IUnitOfWork : IDisposable
{
    IAuthorRepository AuthorRepository { get; }
    IBookRepository BookRepository { get; }
    IMemberRepository MemberRepository { get; }
    IBorrowedBookRepository BorrowedBookRepository { get; }
    Task Save();
}
