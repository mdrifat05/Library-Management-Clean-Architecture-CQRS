using LibraryManagement.Application.DTOs.Authors;
using LibraryManagement.Application.Features.Authors.Requests.Commands;
using LibraryManagement.Application.Features.Authors.Requests.Queries;
using LibraryManagement.Application.Responses;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace LibraryManagement.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class AuthorController : ControllerBase
{
    private readonly IMediator _mediator;

    public AuthorController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet]
    public async Task<ActionResult<List<AuthorDto>>> Get(bool isLoggedInUser = true)
    {
        var leaveAllocations = await _mediator.Send(new GetAuthorListRequest { IsLoggedInUser = isLoggedInUser });
        return Ok(leaveAllocations);
    }
    [HttpGet("{id}")]
    public async Task<ActionResult<AuthorDto>> Get(int id)
    {
        var leaveAllocation = await _mediator.Send(new GetAuthorDetailRequest { ID = id });
        return Ok(leaveAllocation);
    }

    [HttpPost]
    public async Task<ActionResult<BaseCommandResponse>> Post([FromBody] CreateAuthorDto createAuthorDto)
    {
        var command = new CreateAuthorCommand { CreateAuthorDto = createAuthorDto };
        var repsonse = await _mediator.Send(command);
        return Ok(repsonse);
    }

    [HttpPut]
    public async Task<ActionResult> Put([FromBody] UpdateAuthorDto updateAuthorDto)
    {
        var command = new UpdateAuthorCommand { UpdateAuthorDto = updateAuthorDto };
        await _mediator.Send(command);
        return Ok();
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult> Delete(int id)
    {
        var command = new DeleteAuthorCommand { ID = id };
        await _mediator.Send(command);
        return Ok();
    }
}
