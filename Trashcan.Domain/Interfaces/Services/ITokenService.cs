using System.Security.Claims;
using Trashcan.Domain.Dto.AuthToken;
using Trashcan.Domain.Result;

namespace Trashcan.Domain.Interfaces.Services;

public interface ITokenService
{
    string GenerateAccessToken(IEnumerable<Claim> claims);
    
    string GenerateRefreshToken();

    ClaimsPrincipal GetPrincipalFromExpiredToken(string accessToken);

    Task<BaseResult<TokenDto>> RefreshToken(TokenDto dto);

}