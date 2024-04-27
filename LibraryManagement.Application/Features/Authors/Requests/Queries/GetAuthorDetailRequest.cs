using LibraryManagement.Application.DTOs.Authors;
using MediatR;

namespace LibraryManagement.Application.Features.Authors.Requests.Queries;

public class GetAuthorDetailRequest : IRequest<AuthorDto>
{
    public int ID { get; set; }
}
