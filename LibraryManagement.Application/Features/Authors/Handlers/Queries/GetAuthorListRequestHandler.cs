using AutoMapper;
using LibraryManagement.Application.Contracts.Persistence;
using LibraryManagement.Application.DTOs.Authors;
using LibraryManagement.Application.Features.Authors.Requests.Queries;
using MediatR;

namespace LibraryManagement.Application.Features.Authors.Handlers.Queries;

public class GetAuthorListRequestHandler : IRequestHandler<GetAuthorListRequest, List<AuthorDto>>
{
    private readonly IAuthorRepository _authorRepository;
    private readonly IMapper _mapper;

    public GetAuthorListRequestHandler(IAuthorRepository authorRepository, IMapper mapper)
    {
        _authorRepository = authorRepository;   
        _mapper = mapper;
    }
    public async Task<List<AuthorDto>> Handle(GetAuthorListRequest request, CancellationToken cancellationToken)
    {
        var authorList = await _authorRepository.GetAll(cancellationToken);
        return _mapper.Map<List<AuthorDto>>(authorList);
    }
}
