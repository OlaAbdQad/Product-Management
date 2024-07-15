using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Assessment_Task.Service.Contracts;

namespace Assessment_Task.Middleware
{
    public class TokenBlacklistMiddleware
    {
        private readonly RequestDelegate _next;

        public TokenBlacklistMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            var _blacklist = context.RequestServices.GetRequiredService<IBlacklistedTokenService>();

            if (context.Request.Headers.ContainsKey("Authorization"))
            {
                var token = context.Request.Headers["Authorization"].ToString().Replace("Bearer ", "");
                if (await _blacklist.CheckIfTokenIsBlacklisted(token))
                {
                    context.Response.StatusCode = StatusCodes.Status401Unauthorized;
                    await context.Response.WriteAsync("Unauthorized: Token has been blacklisted");
                    return;
                }
            }

            await _next(context);
        }
    }


}