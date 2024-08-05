using Solway.DTO;
using Solway.Interfaces.Services;
using Solway.Models;

using AutoMapper;

namespace Solway.API.Controllers;

public class ContentController : BaseAPIController
{
    private readonly IGenericService<Content> _genericService;
    private readonly IMapper _mapper;

    public ContentController(
        IGenericService<Content> genericService,
        IMapper mapper
    )
    {
        _genericService = genericService;
        _mapper = mapper;
    }

    [HttpGet("{id}")]
    public async Task<ActionResult> GetContentByIdAsync(string id)
    {
        ServerResponse response = await _genericService.GetEntityById(id);
        response.Objects = _mapper.Map<AppUserDTO>(response.Objects);
        return response.StatusCode == 200 ? Ok(response) : NotFound(response);
    }

    [HttpGet]
    public async Task<ActionResult> GetContentAsync()
    {
        ServerResponse response = await _genericService.GetEntities();
        response.Objects = _mapper.Map<AppUserDTO>(response.Objects);
        return response.StatusCode == 200 ? Ok(response) : NotFound(response);
    }

    [HttpPost]
    public async Task<ActionResult> AddContentAsync(ContentDTO content)
    {
        ServerResponse response = await _genericService.AddEntity(_mapper.Map<Content>(content));
        return Ok(response);
    }

    [HttpPut]
    public async Task<ActionResult> UpdateContentAsync(ContentDTO content)
    {
        ServerResponse response = await _genericService.UpdateEntity(_mapper.Map<Content>(content));
        return response.StatusCode == 200 ? Ok(response) : NotFound(response);
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult> DeleteContentAsync(string id)
    {
        var response = await _genericService.DeleteEntity(id);
        return response.StatusCode == 200 ? Ok(response) : NotFound(response);
    }
}