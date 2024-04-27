using FluentValidation;
using LibraryManagement.Application.Contracts.Persistence;
using System.Threading;

namespace LibraryManagement.Application.DTOs.Authors.Validators;

public class UpdateAuthorDtoValidator : AbstractValidator<UpdateAuthorDto>
{
    private readonly IAuthorRepository _authorRepository;
    public UpdateAuthorDtoValidator(IAuthorRepository authorRepository, CancellationToken cancellationToken)
    {
        _authorRepository = authorRepository;
        RuleFor(dto => dto.ID)
            .NotEmpty()
            .MustAsync(async(id, token) =>
            {
                var authorExists = await _authorRepository.Exists(id,cancellationToken);
                return authorExists;
            }).WithMessage("{PropertyName} does not exist.");

        RuleFor(dto => dto.AuthorName)
            .NotEmpty()
            .MinimumLength(3)
            .MaximumLength(50);

        RuleFor(dto => dto.AuthorBio)
            .NotEmpty()
            .MinimumLength(10)
            .MaximumLength(500);
    }
}
