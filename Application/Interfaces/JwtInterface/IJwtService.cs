using Entities.Models.JwtModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces.JwtInterface
{
    public interface IJwtService
    {
        Task<string> GenerateTokenAsync(ApplicationUser user);
        string GenerateRefreshToken();
        ClaimsPrincipal GetClaimsPrincipal(string token);
    }
}
