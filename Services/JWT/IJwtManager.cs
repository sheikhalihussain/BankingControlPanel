using System.Security.Claims;

namespace BankingControlPanel.API.Services.JWT
{
    public interface IJwtManager
    {
        string GenerateToken(IEnumerable<Claim> claims);
        IEnumerable<Claim> GenerateClaim(string email);
    }
}
