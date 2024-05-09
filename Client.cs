using System.Text;
using System.Net;
using System.Net.Sockets;



namespace ConsoleBattleships
{
    public class Client
    {
        int port = 21002;
        private TcpClient _tcpClient;
        
        
        public Client(int port = 21002)
        {
            this.port = port;

            try
            {
                Console.WriteLine("Connecting to server...");
                _tcpClient = new TcpClient();
                _tcpClient.Connect(IPAddress.Loopback, port);
                Console.WriteLine("Connected to server.");
                
                _tcpClient.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
        }
    }
}
