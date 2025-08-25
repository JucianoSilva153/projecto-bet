using Application.Services;
using Microsoft.AspNetCore.Components.Authorization;

namespace BET.Services;

public class CustomAuthenticationStateProvider : AuthenticationStateProvider
{
    private readonly UserService _userService;
    private readonly IHttpContextAccessor _httpContextAccessor;

    public CustomAuthenticationStateProvider(UserService userService, IHttpContextAccessor httpContextAccessor)
    {
        _userService = userService;
        _httpContextAccessor = httpContextAccessor;
    }

    public override async Task<AuthenticationState> GetAuthenticationStateAsync()
    {
        throw new NotImplementedException();
    }
}