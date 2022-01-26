using System.Net;
using System.Net.Sockets;

class Program
{
    static void Main(string[] args)
    {
        var Client = new TcpClient();
        Client.Connect(IPAddress.Loopback.ToString(), 1111);

        var stream = Client.GetStream();
        BinaryWriter writer = new BinaryWriter(stream);

        BinaryReader reader = new BinaryReader(stream);
        
        while (true)
        {
            var msg = Console.ReadLine();
            writer.Write(msg);
            var answer=reader.ReadString();
            Console.WriteLine(answer);
        }


    }

}