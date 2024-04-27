using AutoMapper;
using LibraryManagement.Application.Contracts.Persistence;
using LibraryManagement.Application.DTOs.Authors;
using LibraryManagement.Application.Features.Authors.Requests.Queries;
using MediatR;

namespace LibraryManagement.Application.Features.Authors.Handlers.Queries;

public class GetAuthorDetailRequestHandler : IRequestHandler<GetAuthorDetailRequest, AuthorDto>
{
    private readonly IAuthorRepository _authorRepository;
    private readonly IMapper _mapper;

    public GetAuthorDetailRequestHandler(IAuthorRepository authorRepository, IMapper mapper)
    {
        _authorRepository = authorRepository;
        _mapper = mapper;
    }
    public async Task<AuthorDto> Handle(GetAuthorDetailRequest request, CancellationToken cancellationToken)
    {
        var author = await _authorRepository.Get(request.ID, cancellationToken);
        return _mapper.Map<AuthorDto>(author);
    }
}
