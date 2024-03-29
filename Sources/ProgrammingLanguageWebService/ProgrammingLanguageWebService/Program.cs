using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;

namespace ProgrammingLanguageWebService
{
    public class Program
    {
        #region Methods
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();

                }).UseWindowsService(); 
        #endregion
    }
}
