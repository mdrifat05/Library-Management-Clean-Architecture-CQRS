using MediatR;

namespace LibraryManagement.Application.Features.Authors.Requests.Commands;

public class DeleteAuthorCommand : IRequest<Unit>
{
    public int ID { get; set; }
}
