using System.Text;
using System.Net;
using System.Net.Sockets;

namespace ConsoleBattleships
{
    public class Client
    {
        int port = 21002;
        private TcpClient _tcpClient;
        private Stream stm;
        
        
        public Client(int port = 21002)
        {
            this.port = port;
        }

        public void Connect()
        {
            try
            {
                Console.Clear();
                Console.WriteLine("Connecting to server...");
                _tcpClient = new TcpClient();
                _tcpClient.Connect(IPAddress.Loopback, port);
                stm = _tcpClient.GetStream();
                Console.WriteLine("Connected to server.");
                Console.ReadLine();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                Console.ReadLine();
            }
        }

        public void Send(string message)
        {
            ASCIIEncoding asen= new ASCIIEncoding();
            byte[] bytes=asen.GetBytes(message);
            stm.Write(bytes, 0, bytes.Length);
        }

        public string Listen()
        {
            string message = "";
            byte[] bb=new byte[100];
            int k=stm.Read(bb,0,100);
            for (int i = 0; i < k; i++)
                message += bb[i];
            return message;
        }

        public void Disconnect()
        {
            _tcpClient.Close();
        }
    }
}
