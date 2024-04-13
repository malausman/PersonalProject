using PersonalProject.API.CQRS.Services;
using Microsoft.IdentityModel.Tokens;
using Services.Common.Utils;
using PersonalProject.Utils;

namespace PersonalProject.API.Helper
{
    public static class TokenLifetimeValidator
    {
        public static bool Validate(
           DateTime? notBefore,
           DateTime? expires,
           SecurityToken tokenToValidate,
           TokenValidationParameters @param
       )
        {
            using var serviceScope = ServiceActivator.GetScope();
            var context = serviceScope.ServiceProvider.GetRequiredService<IHttpContextAccessor>().HttpContext;
            var _tokenService = serviceScope.ServiceProvider.GetRequiredService<ITokenService>();
            var token = context.Request.Headers["Authorization"].ToString().Substring(7);
            return _tokenService.ValidateToken(token);
        }
    }
}
