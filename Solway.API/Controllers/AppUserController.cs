using Solway.DTO;
using Solway.Interfaces.Services;

namespace Solway.API.Controllers;

public class AppUserController : BaseAPIController
{
    private readonly IAppUserService _appUserService;

    public AppUserController(IAppUserService appUserService)
    {
        _appUserService = appUserService;
    }

    [HttpGet]
    public async Task<ActionResult> Login(LoginDTO loginDTO)
    {
        ServerResponse response = await _appUserService.Login(loginDTO);
        return response.StatusCode switch
        {
            401 => Unauthorized(response),
            500 => BadRequest(response),
            _ => Ok(response)
        };
    }

    [HttpPost]
    public async Task<ActionResult> Register(RegisterUserDTO registerUserDTO)
    {
        ServerResponse response = await _appUserService.RegisterUser(registerUserDTO);
        return response.StatusCode == 200 ? Ok(response) : BadRequest(response);
    }
}