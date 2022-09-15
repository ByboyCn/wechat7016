using Grpc.Net.Client;
using System;

namespace MG.gRPCClient
{
    public class Client
    {
        static GrpcChannel client;
        static string host = "http://43.226.152.14:7001";
        public static GrpcChannel GetClient(string hosts = "http://43.226.152.14:7001")
        {
            if (client == null || hosts != host) {
                var url = hosts;
                host = hosts;
#if DEBUG
                url = "http://43.226.73.96:7001";
#endif
                client = GrpcChannel.ForAddress(url);
            }
            return client;
        }
    }
}
