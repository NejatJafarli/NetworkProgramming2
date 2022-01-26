using System.Net;
using System.Net.Sockets;
using System.Text;

class Program
{


    static void MainAsync(string[] args)
    {
        var Client = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp);
        var ServerIp = IPAddress.Parse("127.0.0.1");
        var ServerPort = 1111;
        var ServerEndPoint = new IPEndPoint(ServerIp, ServerPort);


        while (true)
        {
            var str=Console.ReadLine();
            var bytes=Encoding.Default.GetBytes(str);
            Client.SendTo(bytes,ServerEndPoint);

        }

    }
}








