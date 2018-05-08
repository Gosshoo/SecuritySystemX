using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace TCPBroadcastCaptureSecuritySystemX
{
    class Program
    {
        

        static void Main(string[] args)
        {
            //IPAddress ip = IPAddress.Parse("127.0.0.1");
            IPAddress ip1 = IPAddress.Parse("192.168.3.243");
            TcpListener serverSocket = new TcpListener(IPAddress.Any, 9090);
            serverSocket.Start();

            while (true)
            {


                TcpClient connectionSocket = serverSocket.AcceptTcpClient();
              
                Console.WriteLine("Server activated");
                Stream ns = connectionSocket.GetStream();
                StreamReader sr = new StreamReader(ns);
                StreamWriter sw = new StreamWriter(ns);
                sw.AutoFlush = true; // enable automatic flushing
                int i = 0;
                var newFile = $"C:/Users/Universe/PhpstormProjects/SecuritySystemX/Images/NCAM{i}.jpg";
                while (true)
                {
                    
                    using (var fs = new FileStream(newFile, FileMode.OpenOrCreate, FileAccess.Write))
                    {

                        ns.CopyTo(fs);


                    }
                   
                    i++;
                    Console.WriteLine("Wrote");
                    




                }
            }
        }
    }
}
