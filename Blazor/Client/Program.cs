using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Net.Http;
using System.Threading.Tasks;
using Blazor.Client.Pages;
using Microsoft.Extensions.Caching.Memory;
using BlazingOrchard.Extensions;
using BlazingOrchard;
using System.Text.Encodings.Web;

namespace Blazor.Client
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebAssemblyHostBuilder.CreateDefault(args);
            builder.RootComponents.Add<Counter>("#app");

            builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });

            var services = builder.Services;

            services
                .AddSingleton<IMemoryCache, MemoryCache>()
                .AddSingleton<HtmlEncoder, DefaultHtmlEncoder>()
                .AddSingleton<IConfiguration>(builder.Configuration)
                .AddBlazingOrchard()
                .AddModules(Modules.GetAssemblies());

            await builder.Build().RunAsync();
        }
    }
    public class DefaultHtmlEncoder : HtmlEncoder
    {
        public override unsafe int FindFirstCharacterToEncode(char* text, int textLength)
        {
            throw new System.NotImplementedException();
        }

        public override unsafe bool TryEncodeUnicodeScalar(int unicodeScalar, char* buffer, int bufferLength, out int numberOfCharactersWritten)
        {
            throw new System.NotImplementedException();
        }

        public override bool WillEncode(int unicodeScalar)
        {
            throw new System.NotImplementedException();
        }

        public override int MaxOutputCharactersPerInputCharacter { get; }
    }
}
