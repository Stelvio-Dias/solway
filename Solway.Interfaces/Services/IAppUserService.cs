using Solway.DTO;

namespace Solway.Interfaces.Services;

public interface IAppUserService
{
    Task<ServerResponse> Login(LoginDTO loginDTO);
    Task<ServerResponse> RegisterUser(RegisterUserDTO registerUserDTO);
}