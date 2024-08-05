using Solway.DTO;
using Solway.Interfaces.Services;
using Solway.Models;

using AutoMapper;
using Microsoft.AspNetCore.Identity;

namespace Solway.Services;

public class AppUserService : IAppUserService
{
    private readonly UserManager<AppUser> _userManager;
    private readonly SignInManager<AppUser> _signInManager;
    private readonly ITokenService _tokenService;
    private readonly IMapper _mapper;

    public AppUserService(
        UserManager<AppUser> userManager, 
        SignInManager<AppUser> signInManager, 
        ITokenService tokenService, 
        IMapper mapper
    )
    {
        _userManager = userManager;
        _signInManager = signInManager;
        _tokenService = tokenService;
        _mapper = mapper;
    }

    public async Task<ServerResponse> Login(LoginDTO loginDTO)
    {
        ServerResponse response = new(200);
        AppUser? user = await _userManager.FindByEmailAsync(loginDTO.Email);

        if (user is null)
        {
            response.StatusCode = 401;
            return response;
        }

        SignInResult result = await _signInManager.CheckPasswordSignInAsync(user, loginDTO.Password, false);

        if (!result.Succeeded)
        {
            response.StatusCode = 401;
            return response;
        }

        AppUserDTO userDTO = _mapper.Map<AppUser, AppUserDTO>(user);

        userDTO.Token = _tokenService.CreateToken(user);

        response.Objects = userDTO;

        return response;
    }

    public async Task<ServerResponse> RegisterUser(RegisterUserDTO registerUserDTO)
    {
        ServerResponse response = new(200);

        if (await CheckEmailExists(registerUserDTO.Email))
        {
            response.StatusCode = 400;
            response.Message = "Email já existe";
            return response;
        }

        AppUser user = _mapper.Map<RegisterUserDTO, AppUser>(registerUserDTO);

        IdentityResult result = await _userManager.CreateAsync(user, registerUserDTO.Password);

        if (result.Errors.Any())
        {
            response.StatusCode = 500;
            return response;
        }

        AppUserDTO userDTO = _mapper.Map<AppUser, AppUserDTO>(user);

        userDTO.Token = _tokenService.CreateToken(user);

        response.Objects = userDTO;

        return response;
    }

    private async Task<bool> CheckEmailExists(string email)
        => await _userManager.FindByEmailAsync(email) is not null;
}