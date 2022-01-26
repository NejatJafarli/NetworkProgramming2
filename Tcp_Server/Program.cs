using System.Net;
using System.Net.Sockets;

class Program
{
    static void Main(string[] args)
    {
        var ip = IPAddress.Loopback;
        var port = 1111;
        var TcpServer = new TcpListener(ip, port);


        TcpServer.Start(100);
        Console.WriteLine("Lisening");
        while (true)
        {
            var client=TcpServer.AcceptTcpClient();
            var stream=client.GetStream();
            BinaryWriter bw=new BinaryWriter(stream);
            BinaryReader br=new BinaryReader(stream);

            while (true)
            {
                var data = br.ReadString();
                Console.WriteLine(data);
                bw.Write("Roger That");
            }

        }
    }
}