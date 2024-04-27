using LibraryManagement.Application.DTOs.Authors;
using MediatR;

namespace LibraryManagement.Application.Features.Authors.Requests.Commands;

public class UpdateAuthorCommand : IRequest<Unit>
{
    public UpdateAuthorDto UpdateAuthorDto { get; set; }
}
