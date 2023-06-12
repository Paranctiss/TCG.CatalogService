using Asp.Versioning;
using MapsterMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using TCG.CatalogService.Application.Pokemon.Query;

namespace TCG.CatalogService.API.Controllers.v1;

[ApiController]
[Route("[controller]")]
[ApiVersion("1.0")]
public class SearchController : ControllerBase
{
    private readonly IMediator _mediator;
    private readonly IMapper _mapper;

    public SearchController(IMediator mediator, IMapper mapper)
    {
        _mediator = mediator;
        _mapper = mapper;
    }

    [HttpGet]
    public async Task<IActionResult> GetItem([FromQuery] string? query, [FromQuery] string extensions, [FromQuery] int pageNumber = 0, [FromQuery] int pageSize = 10)
    {
        string[] idExtensionsArray = extensions.Split(",");
        var result = await _mediator.Send(new GetItemsByNameQuery(query, idExtensionsArray, pageNumber, pageSize));
        return Ok(result);
    }

}