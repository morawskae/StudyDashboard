using StudyDashboardBackend.Dtos;
using StudyDashboardBackend.Models;
using Superpower.Model;

namespace StudyDashboardBackend.Interfaces
{
    public interface IAuthService
    {
        Task<User?> RegisterAsync(UserDto request);
        Task<TokenResponseDto?> LoginAsync(UserDto request);
        Task<TokenResponseDto?> RefreshTokensAsync(RefreshTokenRequestDto request);
        Task<bool> LogoutAsync(string refreshToken);
    }
}