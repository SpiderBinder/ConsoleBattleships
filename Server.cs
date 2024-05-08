using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Net;
using System.Net.Sockets; 


namespace Battleships
{
    class Server 
    {
        int port = 21002;
        private TcpListener server;
        private TcpClient client1, client2;
        private NetworkStream ns1, ns2;



        public Server(){
            this.server = new TcpListener(IPAddress.Loopback, 9999);  

            this.server.Start();  // this will start the server

            while (true)
            {
                Console.WriteLine("Waiting for client 1...");
                this.client1 = server.AcceptTcpClient();
                this.ns1 = client1.GetStream();
                Console.WriteLine("Client 1 connected.\nWaiting for client 2...");
                this.client2 = server.AcceptTcpClient();
                this.ns2 = client2.GetStream();
                Console.WriteLine("Client 2 connected.");
                Broadcast("Clients connected. Starting.");
                

                while (client1.Connected && client2.Connected) // While both clients are connected, do game loop
                {
                    byte[] msg = new byte[1024];
                    this.ns1.Read(msg, 0, msg.Length); // Messages from the wrong player get ignored (robust as hell ik). I'm extremely lazy and this is battleships, give me a break.
                }
            }
        }


        private void Broadcast(string message){
            try{
                Console.WriteLine($"Sending: \"{message}\"");
                byte[] bytemessage = new byte[1024];
                bytemessage = Encoding.Default.GetBytes(message);
                ns1.Write(bytemessage, 0, bytemessage.Length);
                ns2.Write(bytemessage, 0, bytemessage.Length);
            }catch (Exception e){
                Console.WriteLine($"Error Broadcasting: \"{message}\"\n  :{e}");
            }
        }

    }
}