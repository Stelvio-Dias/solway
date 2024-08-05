global using Microsoft.AspNetCore.Mvc;
using Solway.DTO;
using Solway.Errors;

namespace Solway.API.Controllers;

[ApiController]
[Route("api/[controller]")]
[ProducesResponseType(typeof(ServerResponse), StatusCodes.Status200OK)]
[ProducesResponseType(typeof(ApiValidationErrorResponse), StatusCodes.Status400BadRequest)]
[ProducesResponseType(typeof(ApiException), StatusCodes.Status500InternalServerError)]
public class BaseAPIController : ControllerBase { }