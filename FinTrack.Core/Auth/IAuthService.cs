﻿using Microsoft.AspNetCore.Http;
using System.Security.Claims;

namespace FinTrack.Core.Auth
{
    public interface IAuthService
    {
        string GenerateToken(string Email, int Id, string Role); 
        string ComputeHash(string password);
        List<Claim> GetUserClaimsLoged(HttpContext httpContext);
    }
}
