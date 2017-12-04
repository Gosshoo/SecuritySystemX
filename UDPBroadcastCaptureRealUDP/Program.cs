using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace UDPBroadcastCaptureRealUDP
{
    class Program
    {
        private const int Port = 8080;
        static void Main(string[] args)
        {
            using (UdpClient socket = new UdpClient(new IPEndPoint(IPAddress.Any, Port)))
            {
                IPEndPoint remoteEndPoint = new IPEndPoint(0, 0);
                while (true)
                {
                    Console.WriteLine("Waiting for broadcast {0}", socket.Client.LocalEndPoint);
                    

                            byte[] datagramReceived = socket.Receive(ref remoteEndPoint);
                    string message = Encoding.ASCII.GetString(datagramReceived, 0, datagramReceived.Length);
                    Console.WriteLine("Receives {0} bytes from {1} port {2} message {3}", datagramReceived.Length,
                        remoteEndPoint.Address, remoteEndPoint.Port, message);
                    
                    if (message.Contains("Motion"))
                    {
                        InserMotion(message);
                   

                    }
                    if (message.Contains("Sound"))
                    {
                        InsertNoise(message);
                    }
                }
            }
        }

        public static async Task<int> InsertNoise(string message)
        {
            var split = message.Split('!');
        
            Noise noise = new Noise()
            {
                NoiseLevel = split[0],
                DateTime = split[1]

            };
            using (HttpClient client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://securitysystemxrestservice.azurewebsites.net/");
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                var customer1 = JsonConvert.SerializeObject(noise);
                var content = new StringContent(customer1, Encoding.UTF8, "Application/json");
                var response = await client.PostAsync("Service1.svc/noises/", content);
                if (response.IsSuccessStatusCode)
                {
                    return 1;
                }
                return 0;
            }
        }
        public static async Task<int> InserMotion(string message)
        {
            var split = message.Split('!');
            Console.WriteLine(split[2]);
            Motion motion = new Motion()
            {
                MotionLevel = split[0],
                DateTime = split[1]

            };
            using (HttpClient client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://securitysystemxrestservice.azurewebsites.net/");
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                var customer1 = JsonConvert.SerializeObject(motion);
                var content = new StringContent(customer1, Encoding.UTF8, "Application/json");
                var response = await client.PostAsync("Service1.svc/motions/", content);
                if (response.IsSuccessStatusCode)
                {
                    return 1;
                }
                return 0;
            }

        }
    }
}
