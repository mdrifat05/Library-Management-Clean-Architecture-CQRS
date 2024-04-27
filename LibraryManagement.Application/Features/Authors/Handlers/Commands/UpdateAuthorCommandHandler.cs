using AutoMapper;
using LibraryManagement.Application.Contracts.Persistence;
using LibraryManagement.Application.DTOs.Authors.Validators;
using LibraryManagement.Application.Features.Authors.Requests.Commands;
using LibraryManagement.Application.Exceptions;
using MediatR;

namespace LibraryManagement.Application.Features.Authors.Handlers.Commands;

public class UpdateAuthorCommandHandler : IRequestHandler<UpdateAuthorCommand, Unit>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public UpdateAuthorCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public async Task<Unit> Handle(UpdateAuthorCommand request, CancellationToken cancellationToken)
    {
        var validator = new UpdateAuthorDtoValidator(_unitOfWork.AuthorRepository, cancellationToken);
        var validationResult = await validator.ValidateAsync(request.UpdateAuthorDto, cancellationToken);
        if(validationResult.IsValid == false)
        {
            throw new ValidationException(validationResult);
        }
        var author = await _unitOfWork.AuthorRepository.Get(request.UpdateAuthorDto.ID, cancellationToken);

        if (author is null)
        {
            throw new NotFoundException(nameof(author), request.UpdateAuthorDto);
        }

        _mapper.Map(request.UpdateAuthorDto, author);

        await _unitOfWork.AuthorRepository.Update(author, cancellationToken);
        await _unitOfWork.Save();

        return Unit.Value;
    }
}
