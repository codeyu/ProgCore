using System;
using System.Linq;
using MiniWeb.Persistence;
using MiniWeb.Persistence.Abstractions;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json;

namespace MiniWeb
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddSingleton<ICountryRepository>(new CountryRepository());
            // Or, in alternative, let the system create one
            //services.AddSingleton<ICountryRepository, CountryRepository>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env,IServiceProvider provider)
        {
            app.Map("/country", countryApp =>
            {
                countryApp.Run(async (context) =>
                {
                    var country = provider.GetService<ICountryRepository>();
                    var query = context.Request.Query["q"];
                    var list = country.AllBy(query).ToList();
                    var json = JsonConvert.SerializeObject(list);

                    await context.Response.WriteAsync(json);
                });
            });

            // Work as a catch-all
            app.Run(async (context) =>
            {
                await context.Response.WriteAsync("Invalid call");
            });

            // Try this code to see that without app.Map the same output is served for each URL
            //app.Run(async (context) =>
            //{
            //    var country = provider.GetService<ICountryRepository>();
            //    var query = context.Request.Query["q"];
            //    var list = country.AllBy(query).ToList();
            //    var json = JsonConvert.SerializeObject(list);

            //    await context.Response.WriteAsync(json);
            //});
        }
    }
}
