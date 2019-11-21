using System;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;

namespace UDPService
{
    class Server
    {
        static void Main(string[] args)
        {
            UdpClient udpServer = new UdpClient(0);

            udpServer.EnableBroadcast = true;
            
            IPEndPoint ipEnd = new IPEndPoint(IPAddress.Broadcast, 5005);


            try
            {
                int nr = 1;
                while (true)
                {
                    string sendData = "Server: " + nr;
                    //sendData = Newtonsoft.Json.JsonConvert.SerializeObject(obj);
                    Byte[] sendBytes = Encoding.ASCII.GetBytes(sendData);
                    udpServer.Send(sendBytes, sendBytes.Length, ipEnd);
                    Console.WriteLine(sendData);
                    nr++;
                    Thread.Sleep(1000);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                Console.ReadLine();
            }
        }
    }
}
