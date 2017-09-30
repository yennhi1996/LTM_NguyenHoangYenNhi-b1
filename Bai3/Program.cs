using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;

namespace Bai3
{
    class Program
    {
        private static string strIP;		//input from user
        private static int inpMask;	//input from user

        private static List<int> ip;
        private static List<int> mask;
        private static List<int> netID;
        private static List<int> broadcast;

        private static void input()
        {
            Console.Write("IP: ");
            strIP = Console.ReadLine();
            Console.Write("Broadcast: ");
            inpMask = Convert.ToInt32(Console.ReadLine());
        }

        private static void preProcess()
        {
            //convert string ip into ip
            ip = new List<int>();
            mask = new List<int>();
            foreach (string octet in strIP.Split('.'))
            {
                ip.Add(Convert.ToInt32(octet));
            }

            //convert input broadcast to 4 octets
            int numberOfFullOctet = inpMask / 8;				// 22/8 = 2
            int bitRemains = inpMask - numberOfFullOctet * 8;	// 22 - 8*2 = 6

            for (int i = 0; i < numberOfFullOctet; i++)
            {
                mask.Add(255);		//255.255.x.x
            }
            if (bitRemains > 0)
            {
                mask.Add((int)Math.Pow(2.0, bitRemains));		//255.255.64.x

                for (int i = numberOfFullOctet + 1; i < 4; i++)
                {		//255.255.64.0
                    mask.Add(0);
                }
            }
            else
            {
                for (int i = numberOfFullOctet + 1; i <= 4; i++)
                {		//255.255.64.0
                    mask.Add(0);
                }
            }
        }

        private static void getBroadcast()
        {
            broadcast = new List<int>();
            for (int i = 0; i < 4; i++)
            {
                broadcast.Add(ip[i] ^ mask[i]);
            }
            Console.Write("Broadcast: ");
            foreach (int octet in broadcast)
            {
                Console.Write(octet + ".");
            }
            Console.WriteLine();
        }

        private static void getNetID()
        {
            netID = new List<int>();
            for (int i = 0; i < 4; i++)
            {
                netID.Add(ip[i] & mask[i]);
            }
            Console.Write("Net ID: ");
            foreach (int octet in netID)
            {
                Console.Write(octet + ".");
            }
            Console.WriteLine('\n');
        }

        static void Main(string[] args)
        {
            input();
            preProcess();
            getNetID();
            getBroadcast();
        }
    }
}
