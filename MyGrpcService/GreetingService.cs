using ProtoBuf.Grpc;
using System.Runtime.Serialization;
using System.ServiceModel;

namespace MyGrpcService;

[ServiceContract]
public interface IGreetingService
{
    [OperationContract]
    Task<HelloReply> SayHello(HelloRequest request, CallContext context = default);
}

[DataContract]
public class HelloReply
{
    [DataMember(Order = 1)]
    public string Message { get; set; } = "";
}
[DataContract]
public class HelloRequest
{
    [DataMember(Order = 1)]
    public string Name { get; set; } = "";
}
