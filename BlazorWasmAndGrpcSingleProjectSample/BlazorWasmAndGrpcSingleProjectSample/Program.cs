using BlazorWasmAndGrpcSingleProjectSample.Client.Pages;
using BlazorWasmAndGrpcSingleProjectSample.Components;
using BlazorWasmAndGrpcSingleProjectSample.Services;
using ProtoBuf.Grpc.Server;

var builder = WebApplication.CreateBuilder(args);

// gRPC �T�[�r�X��ǉ�
builder.Services.AddCodeFirstGrpc();
// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveWebAssemblyComponents();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseWebAssemblyDebugging();
}
else
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();
app.UseAntiforgery();

// gRPC �̃T�[�r�X�̒ǉ�
app.UseGrpcWeb();
app.MapGrpcService<GreetingService>().EnableGrpcWeb();

app.MapRazorComponents<App>()
    .AddInteractiveWebAssemblyRenderMode()
    .AddAdditionalAssemblies(typeof(BlazorWasmAndGrpcSingleProjectSample.Client._Imports).Assembly);

app.Run();
