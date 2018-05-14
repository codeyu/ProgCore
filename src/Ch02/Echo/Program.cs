
//添加不用的程序集会报异常：
//Program.cs(21,25): error CS1501: No overload for method 'Run' takes 1 arguments
using System;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;

namespace Echo
{
    public class Program
    {
        public static void Main(string[] args)
        {
            BuildWebHost(args).Run();
        }

        public static IWebHost BuildWebHost(string[] args) =>
            new WebHostBuilder()
                .UseKestrel()
                .UseIISIntegration()
                .Configure(app => {
                    app.Run(async (context) => {
                        var path = context.Request.Path;
                        await context.Response.WriteAsync("<h1>" + path + "</h1>");
                    });
                })
                .Build();
    }
}
