using System.Security.Claims;

namespace BankingControlPanel.API.Services.JWT
{
    public interface IJwtManager
    {
        public string GenerateToken(     claims);
    }
}
