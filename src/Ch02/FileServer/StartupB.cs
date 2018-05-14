using System.IO;
using FileServer.Common;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.FileProviders;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
namespace FileServer
{
    public class StartupB
    {
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            app.Use(async (context, nextMiddleware) =>
            {
                await context.Response.WriteAsync("ONE-before<hr>");
                await nextMiddleware();
                await context.Response.WriteAsync("ONE-after<hr>");
            });
            app.Use(async (context, nextMiddleware) =>
            {
                await context.Response.WriteAsync("TWO-before<hr>");
                await nextMiddleware();
                await context.Response.WriteAsync("TWO-after<hr>");
            });
            app.Use(async (context, nextMiddleware) =>
            {
                await context.Response.WriteAsync("THREE-before<hr>");
                await nextMiddleware();
                await context.Response.WriteAsync("THREE-after<hr>");
            });

            //app.Use(async (context, nextMiddleware) =>
            //{
            //    // first pass here
            //    var isMobile = context.IsMobileDevice();
            //    context.Items["Mobile"] = isMobile;

            //    if (isMobile)
            //    {
            //        await context.Response.WriteAsync("MOBILE DEVICE DETECTED");
            //        return;
            //    }

            //    await nextMiddleware();   // optional, but ...

            //    // second pass here
            //});


            // Enable serving files from the configured web root folder (i.e., WWWROOT)
            //app.UseDefaultFiles();
            //app.UseStaticFiles();

            //// Enable serving files from \Assets located under the root folder of the site
            //app.UseStaticFiles(new StaticFileOptions()
            //{
            //    FileProvider = new PhysicalFileProvider(
            //        Path.Combine(Directory.GetCurrentDirectory(), @"Assets")),
            //    RequestPath = new PathString("/Public/MyAssets")
            //});

            app.Run(async (context) =>
            {
                //await context.Response.WriteAsync(context.Items["Mobile"].ToString());
                await context.Response.WriteAsync("<h1>DONE</h1><hr>");
            });
        }
    }
}