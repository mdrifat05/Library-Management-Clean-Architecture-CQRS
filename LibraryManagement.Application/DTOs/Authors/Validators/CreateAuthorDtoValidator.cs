using FluentValidation;

namespace LibraryManagement.Application.DTOs.Authors.Validators;

public class CreateAuthorDtoValidator : AbstractValidator<CreateAuthorDto>
{
    public CreateAuthorDtoValidator()
    {
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
