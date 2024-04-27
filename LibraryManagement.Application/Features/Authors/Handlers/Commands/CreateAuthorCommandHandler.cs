using AutoMapper;
using LibraryManagement.Application.Contracts.Persistence;
using LibraryManagement.Application.DTOs.Authors.Validators;
using LibraryManagement.Application.Features.Authors.Requests.Commands;
using LibraryManagement.Application.Responses;
using LibraryManagement.Domain.Entities;
using MediatR;

namespace LibraryManagement.Application.Features.Authors.Handlers.Commands;

public class CreateAuthorCommandHandler : IRequestHandler<CreateAuthorCommand, BaseCommandResponse>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;
    public CreateAuthorCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }
    public async Task<BaseCommandResponse> Handle(CreateAuthorCommand request, CancellationToken cancellationToken)
    {
        var response = new BaseCommandResponse();
        var validator = new CreateAuthorDtoValidator();
        var validatorResult = await validator.ValidateAsync(request.CreateAuthorDto);
        if (validatorResult.IsValid == false)
        {
            response.Success = false;
            response.Message = "Author Creation Failed";
            response.Errors = validatorResult.Errors.Select(x => x.ErrorMessage).ToList();
        }
        else
        {
            var createAuthor = _mapper.Map<Author>(request.CreateAuthorDto);

            createAuthor = await _unitOfWork.AuthorRepository.Add(createAuthor, cancellationToken);
            await _unitOfWork.Save();
            
            response.Success = true;
            response.Message = "Creation Successful";
            response.Id = createAuthor.ID;
        }
        return response;    
    }
}
