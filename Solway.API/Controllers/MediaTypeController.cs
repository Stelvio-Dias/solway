using AutoMapper;
using Solway.DTO;
using Solway.Interfaces.Services;
using Solway.Models;

using System.Net.Http;

namespace Solway.API.Controllers;

public class MediaTypeController : BaseAPIController
{
    private readonly IGenericService<MediaType> _genericService;
    private readonly IMapper _mapper;
    private readonly HttpClient _httpClient;

    public MediaTypeController(
        IGenericService<MediaType> genericService,
        IMapper mapper
,
        HttpClient httpClient)
    {
        _genericService = genericService;
        _mapper = mapper;
        _httpClient = httpClient;
    }

    [HttpGet("{id}")]
    public async Task<ActionResult> GetMediaTypeByIdAsync(string id)
    {
        ServerResponse response = await _genericService.GetEntityById(id);
        response.Objects = _mapper.Map<AppUserDTO>(response.Objects);
        return response.StatusCode == 200 ? Ok(response) : NotFound(response);
    }

    [HttpGet]
    public async Task<ActionResult> GetMediaTypesAsync()
    {
        ServerResponse response = await _genericService.GetEntities();
        response.Objects = _mapper.Map<AppUserDTO>(response.Objects);
        return response.StatusCode == 200 ? Ok(response) : NotFound(response);
    }

    [HttpPost]
    public async Task<ActionResult> AddMediaTypeAsync(MediaTypeDTO mediaType)
    {
        ServerResponse response = await _genericService.AddEntity(_mapper.Map<MediaType>(mediaType));
        return Ok(response);
    }

    [HttpPut]
    public async Task<ActionResult> UpdateMediaTypeAsync(MediaTypeDTO mediaType)
    {
        ServerResponse response = await _genericService.AddEntity(_mapper.Map<MediaType>(mediaType));
        return response.StatusCode == 200 ? Ok(response) : NotFound(response);
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult> DeleteMediaTypeAsync(string id)
    {
        ServerResponse response = await _genericService.DeleteEntity(id);
        return response.StatusCode == 200 ? Ok(response) : NotFound(response);
    }
}