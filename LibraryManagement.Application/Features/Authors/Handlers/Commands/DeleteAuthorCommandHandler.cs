using LibraryManagement.Application.Contracts.Persistence;
using LibraryManagement.Application.Exceptions;
using LibraryManagement.Application.Features.Authors.Requests.Commands;
using LibraryManagement.Application.Responses;
using MediatR;

namespace LibraryManagement.Application.Features.Authors.Handlers.Commands;

public class DeleteAuthorCommandHandler : IRequestHandler<DeleteAuthorCommand, Unit>
{
    private readonly IUnitOfWork _unitOfWork;
    public DeleteAuthorCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }
    public async Task<Unit> Handle(DeleteAuthorCommand request, CancellationToken cancellationToken)
    {
        var author = await _unitOfWork.AuthorRepository.Get(request.ID, cancellationToken);
        if (author == null)
        {
            throw new NotFoundException(nameof(author), request.ID);
        }
        await _unitOfWork.AuthorRepository.Delete(author, cancellationToken);
        await _unitOfWork.Save();

        return Unit.Value;
    }
}
