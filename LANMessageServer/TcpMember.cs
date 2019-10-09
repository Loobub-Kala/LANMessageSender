using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace LANMessageServer
{
    class TcpMember
    {
        public TcpClient tcpClient;
        public NetworkStream networkStream;
        public BinaryReader reader;
        public BinaryWriter writer;
        public String name;
        public Boolean state;

        public TcpMember()
        {
            tcpClient = null;
            networkStream = null;
            reader = null;
            writer = null;
            name = null;
            state = false;
        }
        public TcpMember(TcpClient tcp)
        {
            tcpClient = tcp;
            networkStream = tcpClient.GetStream();
            reader = new BinaryReader(networkStream);
            writer = new BinaryWriter(networkStream);
            name = null;
            state = true;
        }
    }
}
