using System.Text;
using System.Net;
using System.Net.Sockets;



namespace ConsoleBattleships
{
    public class Client
    {
        int port = 21002;
        
        public Client(int port = 21002)
        {
            this.port = port;
        }
    }
}
