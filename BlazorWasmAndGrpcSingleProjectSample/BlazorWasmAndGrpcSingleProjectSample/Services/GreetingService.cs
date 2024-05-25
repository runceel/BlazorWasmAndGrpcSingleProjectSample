using MyGrpcService;
using ProtoBuf.Grpc;

namespace BlazorWasmAndGrpcSingleProjectSample.Services;

public class GreetingService : IGreetingService
{
    public Task<HelloReply> SayHello(HelloRequest request, CallContext context = default) =>
        Task.FromResult(new HelloReply { Message = $"Hello, {request.Name}!" });
}
