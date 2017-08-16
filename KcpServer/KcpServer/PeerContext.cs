﻿using System.Collections.Concurrent;
using System.Net;

namespace KcpServer
{
    /// <summary>
    /// 用于保存建立连接时候的信息
    /// </summary>
    public class PeerContext
    {
        public PeerContext()
        {
        }

        public byte[] ApplicationData { get; set; }
        public EndPoint RemoteEP { get; set; }
        public EndPoint LocalEP { get; set; }
        public int SessionId { get; internal set; }
        public ConnectionManager ConnectionManager { get; internal set; }
    }
}