﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TestClient
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            Form form=null;
            Console.WriteLine("All test:");
            Console.WriteLine("1 PureUdp test");
            Console.WriteLine("2 PureKcp test");
            Console.WriteLine("3 Udp+Kcp mix test");
            Console.WriteLine("4 PureKcp withflush minrto mix test");
            Console.WriteLine("other: exit");
            string input = "";           
            Console.WriteLine("input 1~4:");
            input = Console.ReadLine();
            switch (input.Trim())
            {
                case "0":
                    form = new ClientForm1();
                    break;
                case "1":
                    form = new ClientUdp();
                    break;
                case "2":                         
                    form = new ClientKcp();
                    break;
                case "3":
                    form = new ClientMix();
                    break;
                case "4":                    
                    KcpClient.KcpSetting.Default.RTO = 1;
                    KcpClient.KcpSetting.Default.NoDelay = 1;
                    KcpClient.KcpSetting.Default.NoDelayInterval = 1;
                    KcpClient.KcpSetting.Default.NoDelayResend = 10;
                    KcpClient.KcpSetting.Default.NoDelayNC = 1;
                    KcpClient.KcpSetting.Default.SndWindowSize = 2048;
                    KcpClient.KcpSetting.Default.RecWindowSize = 2048;
                    form = new ClientKcp();
                    break;
                default:
                    return;
                    break;
            }

            Application.Run(form);
        }
    }
}
