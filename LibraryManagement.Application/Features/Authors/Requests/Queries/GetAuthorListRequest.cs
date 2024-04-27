using LibraryManagement.Application.DTOs.Authors;
using MediatR;

namespace LibraryManagement.Application.Features.Authors.Requests.Queries;

public class GetAuthorListRequest : IRequest<List<AuthorDto>>
{
    public bool IsLoggedInUser { get; set; }
}
