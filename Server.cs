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
        private TcpClient client0, client1;
        private NetworkStream ns0, ns1;



        public Server(){
            this.server = new TcpListener(IPAddress.Loopback, 9999);  

            this.server.Start();  // this will start the server

            while (true)
            {
                Console.WriteLine("Waiting for client 1...");
                this.client0 = server.AcceptTcpClient();
                this.ns0 = client0.GetStream();
                Console.WriteLine("Client 1 connected.\nWaiting for client 2...");
                this.client1 = server.AcceptTcpClient();
                this.ns1 = client1.GetStream();
                Console.WriteLine("Client 2 connected.");
                Broadcast("Clients connected. Starting.");
                

                while (client1.Connected && client1.Connected) // While both clients are connected, do game loop
                {
                    // Do game logic stuff here ig idfk.
                }
            }
        }


        private void Broadcast(string message){
            try{
                Console.WriteLine($"Sending: \"{message}\"");
                byte[] bytemessage = new byte[1024];
                bytemessage = Encoding.Default.GetBytes(message);
                ns0.Write(bytemessage, 0, bytemessage.Length);
                ns1.Write(bytemessage, 0, bytemessage.Length);
            }catch (Exception e){
                Console.WriteLine($"Error Broadcasting: \"{message}\"\n  :{e}");
            }
        }
        
        //Send message to single client.
        private void Send(string message, bool client){
            byte[] bytemessage = new byte[1024];
            bytemessage = Encoding.Default.GetBytes(message);
            (client? ns1 : ns0).Write(bytemessage, 0, bytemessage.Length);
        }

    }
}