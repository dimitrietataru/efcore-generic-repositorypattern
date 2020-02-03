using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;
using System.Threading.Tasks;

namespace EFCore.RepositoryPattern.Sample
{
    public sealed class Program
    {
        public async static Task Main(string[] args)
        {
            await Host
                .CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder => webBuilder.UseStartup<Startup>())
                .Build()
                .RunAsync()
                .ConfigureAwait(continueOnCapturedContext: false);
        }
    }
}
