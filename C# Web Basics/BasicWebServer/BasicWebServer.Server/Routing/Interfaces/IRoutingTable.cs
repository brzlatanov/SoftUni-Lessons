using BasicWebServer.Server.HTTP;

namespace BasicWebServer.Server.Routing.Interfaces
{
    public interface IRoutingTable
    {
        IRoutingTable Map(Method method, string path, Func<Request, Response> responseFunction);
    }
}
