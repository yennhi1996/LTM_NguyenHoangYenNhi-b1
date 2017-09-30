using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;

namespace Bai2
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Nhap ten mien va IP: ");
            string host = Console.ReadLine();
            IPHostEntry e = Dns.GetHostEntry(host);
            Console.WriteLine("Hostname: {0}", e.HostName);
            foreach (string s in e.Aliases)
                Console.WriteLine("Aliases {0}:", s);
            foreach (IPAddress i in e.AddressList)
                Console.WriteLine("IP: {0}", i);
        }
    }
}