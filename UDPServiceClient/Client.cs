using System;
using System.Net;
using System.Net.Sockets;
using System.Text;

namespace UDPServiceClient
{
    class Client
    {
        static void Main(string[] args)
        {
            UdpClient udpClient = new UdpClient(5005);

            IPEndPoint remoteIpEnd = new IPEndPoint(IPAddress.Any, 5005); //

            try
            {
                while(true)
                {
                    Console.WriteLine("Trying to receive data");
                    Byte[] receiveBytes = udpClient.Receive(ref remoteIpEnd);
                    string receivedData = Encoding.ASCII.GetString(receiveBytes);
                    //Object object = Newtonsoft.Json.JsonConvert.DeserializeObject<Object>(receiveBytes);
                    Console.WriteLine(receivedData);
                    Console.WriteLine("Data received: " + remoteIpEnd.Port);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }
    }
}