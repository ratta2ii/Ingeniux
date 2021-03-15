using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using ToDoList.Models;

namespace ToDoList {

    public class Startup {
        
        public Startup (IWebHostEnvironment env) {
            var builder = new ConfigurationBuilder ()
                .SetBasePath (env.ContentRootPath)
                .AddEnvironmentVariables ();
            Configuration = builder.Build ();
        }

        public IConfigurationRoot Configuration { get; }

        public void ConfigureServices (IServiceCollection services) {
            //! IMPORTANT: Data is only being seeded in this way to test loading and 
            //! parsing an XML file
            Item.SeedItemsFromXmlTesting();
            services.AddMvc ();
        }

        public void Configure (IApplicationBuilder app) {
            app.UseDeveloperExceptionPage ();
            app.UseRouting ();

            app.UseEndpoints (routes => {
                routes.MapControllerRoute ("default", "{controller=Home}/{action=Index}/{id?}");
            });

            app.Run (async (context) => {
                await context.Response.WriteAsync ("No Page here");
            });
        }
    }
}