using System.Net;
using System.Text;

namespace API.Middlewares;

public class SwaggerBasicAuthMiddleware
{

    private readonly RequestDelegate next;
    private readonly ConfigurationManager _configurationManager;

    public SwaggerBasicAuthMiddleware(RequestDelegate next, ConfigurationManager configurationManager)
    {
        this.next = next;
        this._configurationManager = configurationManager;
    }

    public async Task InvokeAsync(HttpContext context)
    {
        // Make sure we are hitting the swagger path, and not doing it locally as it just gets annoying :-)
        if (context.Request.Path.StartsWithSegments("/swagger") /* && !IsLocalRequest(context) */)
        {
            string authHeader = context.Request.Headers["Authorization"];
            if (authHeader != null && authHeader.StartsWith("Basic "))
            {
                // Get the encoded username and password
                var encodedUsernamePassword = authHeader.Split(' ', 2, StringSplitOptions.RemoveEmptyEntries)[1]?.Trim();

                // Decode from Base64 to string
                var decodedUsernamePassword = Encoding.UTF8.GetString(Convert.FromBase64String(encodedUsernamePassword));

                // Split username and password
                var username = decodedUsernamePassword.Split(':', 2)[0];
                var password = decodedUsernamePassword.Split(':', 2)[1];

                // Check if login is correct
                if (IsAuthorized(username, password))
                {
                    await next.Invoke(context);
                    return;
                }
            }

            // Return authentication type (causes browser to show login dialog)
            context.Response.Headers["WWW-Authenticate"] = "Basic";

            // Return unauthorized
            context.Response.StatusCode = (int)HttpStatusCode.Unauthorized;
        }
        else
        {
            await next.Invoke(context);
        }
    }

    public bool IsAuthorized(string username, string password)
    {
        // Check that username and password are correct
        var userNameFromConfig = (string) _configurationManager["Admin:Username"];
        var passwordFromConfig = (string) _configurationManager["Admin:Password"];

        // Console.WriteLine("/**************/");
        // Console.WriteLine(userNameFromConfig);
        // Console.WriteLine(passwordFromConfig);

        return username.Equals(userNameFromConfig, StringComparison.InvariantCultureIgnoreCase)
                && password.Equals(passwordFromConfig);
    }

    public bool IsLocalRequest(HttpContext context)
    {
        // Console.WriteLine("/**** LOCAL ****/");

        // Handle running using the Microsoft.AspNetCore.TestHost and the site being run entirely locally in memory without an actual TCP/IP connection
        if (context.Connection.RemoteIpAddress == null && context.Connection.LocalIpAddress == null)
        {
            return true;
        }
        if (context.Connection.RemoteIpAddress.Equals(context.Connection.LocalIpAddress))
        {
            return true;
        }
        if (IPAddress.IsLoopback(context.Connection.RemoteIpAddress))
        {
            return true;
        }
        return false;
    }
}