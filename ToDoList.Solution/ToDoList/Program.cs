using System.IO;
using Microsoft.AspNetCore.Hosting;

namespace ToDoList 
{
    public class Program 
    {
        public static void Main (string[] args) 
        {
            var host = new WebHostBuilder ()
                .UseKestrel ()
                .UseContentRoot (Directory.GetCurrentDirectory ())
                .UseWebRoot("wwwroot")
                .UseIISIntegration ()
                .UseStartup<Startup> ()
                .Build ();

            host.Run ();
        }
    }
}