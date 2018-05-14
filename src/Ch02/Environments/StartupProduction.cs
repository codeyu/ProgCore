using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
namespace Environments
{
    public class StartupProduction
    {
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            app.Run(async (context) =>
            {
                await context.Response
                .WriteAsync("Courtesy of <b>Programming ASP.NET Core</b>!" +
                    "<hr>" +
                    "TYPE=StartupProduction<br>" +
                    "ENVIRONMENT=" + env.EnvironmentName);
            });
        }
    }
}