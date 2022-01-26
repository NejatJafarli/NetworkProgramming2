using System.Net;
using System.Net.Sockets;
using System.Text;

class Program
{
    static void Main(string[] args) => MainAsync(args).GetAwaiter().GetResult();


    static async Task MainAsync(string[] args)
    {
        var listener = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp);
        var port = 1111;
        var ip = IPAddress.Parse("127.0.0.1");
        var Ep = new IPEndPoint(ip, port);

        listener.Bind(Ep);
        var Buffer = new byte[ushort.MaxValue];

        var Segment = new ArraySegment<byte>(Buffer);

        EndPoint Client = new IPEndPoint(IPAddress.Any, 0);

        while (true)
        {

            var res = await listener.ReceiveFromAsync(Segment, SocketFlags.None,Client);
            var len = res.ReceivedBytes;
            var ClientendPoint = res.RemoteEndPoint;
            var str = Encoding.Default.GetString(Buffer, 0, len);
            Console.WriteLine($"{ClientendPoint} msg:{str}");
        }


    }
}