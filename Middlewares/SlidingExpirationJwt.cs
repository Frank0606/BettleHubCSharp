using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using BettleHubCsharp.Services;

namespace BettleHubCsharp.Middlewares;

public class SlidingExpirationJwt(RequestDelegate next)
{
    private readonly RequestDelegate _next = next;

    public async Task InvokeAsync(HttpContext context, JwtTokenService jwtTokenService)
    {
        try
        {
            string? authorization = context.Request.Headers.Authorization;
            JwtSecurityToken? token = null;

            if (!string.IsNullOrEmpty(authorization) && authorization.StartsWith("Bearer"))
            {
                token = new JwtSecurityTokenHandler().ReadJwtToken(authorization[7..]);
            }

            if (token != null && token.ValidTo > DateTime.UtcNow)
            {
                TimeSpan timeRemaining = token.ValidTo.Subtract(DateTime.UtcNow);
                if (timeRemaining.TotalMinutes < 5)
                {
                    var claims = new List<Claim>();

                    var nameClaim = context.User.FindFirstValue(ClaimTypes.Name);
                    if (!string.IsNullOrEmpty(nameClaim))
                    {
                        claims.Add(new Claim(ClaimTypes.Name, nameClaim));
                    }

                    var givenNameClaim = context.User.FindFirstValue(ClaimTypes.GivenName);
                    if (!string.IsNullOrEmpty(givenNameClaim))
                    {
                        claims.Add(new Claim(ClaimTypes.GivenName, givenNameClaim));
                    }

                    var roleClaim = context.User.FindFirstValue(ClaimTypes.Role);
                    if (!string.IsNullOrEmpty(roleClaim))
                    {
                        claims.Add(new Claim(ClaimTypes.Role, roleClaim));
                    }

                    if (claims.Count > 0)
                    {
                        var newToken = jwtTokenService.GeneraToken(claims);
                        context.Response.Headers.Append("Set-Authorization", newToken);
                    }
                }
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }

        await _next(context);
    }
}

public static class SlidingExpirationJwtExtensions
{
    public static IApplicationBuilder UseSlidingExpirationJwt(this IApplicationBuilder builder)
    {
        return builder.UseMiddleware<SlidingExpirationJwt>();
    }
}