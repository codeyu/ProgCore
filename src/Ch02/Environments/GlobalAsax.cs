using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
namespace Environments
{
    public class GlobalAsax
    {
        public void Configure(IApplicationBuilder app)
        {
            app.Run(async (context) =>
            {
                await context.Response.WriteAsync("GLOBALASAX<br>");
                await context.Response.WriteAsync("Courtesy of <b>Programming ASP.NET Core</b>!");
            });
        }
    }
}