using Microsoft.AspNetCore.Http;
using System;
using System.Security.Claims;
using System.Security.Principal;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Assignment.Api.Core
{
    /// <summary>
    /// 
    /// </summary>
    public class AuthenticationMiddleware
    {
        /// <summary>
        /// The next
        /// </summary>
        private readonly RequestDelegate _next;

        /// <summary>
        /// Initializes a new instance of the <see cref="AuthenticationMiddleware" /> class.
        /// </summary>
        /// <param name="next">The next.</param>
        public AuthenticationMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        /// <summary>
        /// Invokes the specified context.
        /// </summary>
        /// <param name="context">The context.</param>
        /// <param name="userService">The user service.</param>
        public async Task Invoke(HttpContext context, IUserService userService)
        {            
            string authHeader = context.Request.Headers["Authorization"];
            if (context.Request.Path.Value.Contains("swagger"))
            {
                await _next.Invoke(context);
            }
            else
            {
                if (authHeader != null && authHeader.StartsWith("Basic"))
                {
                    //Extract credentials
                    string encodedUsernamePassword = authHeader.Substring("Basic ".Length).Trim();
                    Encoding encoding = Encoding.GetEncoding("iso-8859-1");
                    string usernamePassword = encoding.GetString(Convert.FromBase64String(encodedUsernamePassword));

                    int seperatorIndex = usernamePassword.IndexOf(':');

                    var username = usernamePassword.Substring(0, seperatorIndex);
                    var password = usernamePassword.Substring(seperatorIndex + 1);
                    var validUser = userService.AuthenticateUser(username, password);
                    
                    if (validUser != null)
                    {
                        // attach user to context on successful jwt validation
                        context.Items["Userid"] = validUser.Id;
                        await _next.Invoke(context);
                    }
                    else
                    {
                        context.Response.StatusCode = 401; //Unauthorized
                        return;
                    }
                }
                else
                {
                    // no authorization header
                    context.Response.StatusCode = 401; //Unauthorized
                    return;
                }
            }
            
        }
    }
}
