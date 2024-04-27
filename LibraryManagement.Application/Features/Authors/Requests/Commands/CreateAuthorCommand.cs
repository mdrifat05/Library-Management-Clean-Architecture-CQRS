using LibraryManagement.Application.DTOs.Authors;
using LibraryManagement.Application.Responses;
using MediatR;

namespace LibraryManagement.Application.Features.Authors.Requests.Commands;

public class CreateAuthorCommand : IRequest<BaseCommandResponse>
{
    public CreateAuthorDto CreateAuthorDto { get; set; }
}
