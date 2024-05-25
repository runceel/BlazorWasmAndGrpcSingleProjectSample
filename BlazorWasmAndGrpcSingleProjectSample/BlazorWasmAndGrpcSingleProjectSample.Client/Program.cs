using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using ProtoBuf.Grpc.Configuration;
using MyGrpcService;
using Grpc.Net.Client.Web;
using Grpc.Net.Client;
using ProtoBuf.Grpc.Client;

var builder = WebAssemblyHostBuilder.CreateDefault(args);

// クライアントを追加
builder.Services.AddSingleton(sp =>
{
    var httpHandler = new GrpcWebHandler(GrpcWebMode.GrpcWeb, new HttpClientHandler());
    return GrpcChannel.ForAddress(
        builder.HostEnvironment.BaseAddress,
        new GrpcChannelOptions
        {
            HttpHandler = httpHandler,
        });
});
builder.Services.AddTransient<IGreetingService>(sp =>
{
    var channel = sp.GetRequiredService<GrpcChannel>();
    return channel.CreateGrpcService<IGreetingService>();
});

await builder.Build().RunAsync();
