﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KcpServer;

namespace TestServer
{
    class TestApplication : KcpServer.ApplicationBase
    {
        public override PeerBase CreatePeer(PeerContext peerContext)
        {
            var peertype = Encoding.UTF8.GetString(peerContext.ApplicationData);
            if (peertype == "testpeer")
            {
                return new TestPeer(peerContext);
            }else if (peertype == "bigbufpeer")
            {
                return new BigBuffPeer(peerContext);
            }
            else
            {
                Console.WriteLine($"NotImplementedPeer");
                return null;
            }
        }

        public override void Setup()
        {
            Console.WriteLine($"{nameof(TestApplication)} {nameof(Setup)} {LocalEndPoint}");
        }

        public override void TearDown()
        {
            Console.WriteLine($"{nameof(TestApplication)} {nameof(TearDown)}");
        }



    }
}
