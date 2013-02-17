using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace XbmcNet
{
    internal delegate void MessageReceivedEvent(object sender, MessageReceivedEventArgs args);

    internal class MessageReceivedEventArgs : EventArgs
    {
        public string Message { get; set; }
    }

    internal class TcpReader
    {
        private const int BufferSize = 1024;

        private readonly Encoding _messageEncoding;
        private readonly NetworkStream _ns;

        public TcpReader(NetworkStream ns, Encoding messageEncoding)
        {
            _ns = ns;
            _messageEncoding = messageEncoding;
        }

        public event MessageReceivedEvent MessageReceived;

        public void Start()
        {
            Task.Factory.StartNew(Listen);
        }

        private void Listen()
        {
            try
            {
                int read;
                do
                {
                    var buf = new byte[BufferSize];
                    read = _ns.Read(buf, 0, buf.Length);
                    if (read > 0)
                    {
                        string msg = _messageEncoding.GetString(buf, 0, read);

                        if (MessageReceived != null)
                        {
                            MessageReceived(this, new MessageReceivedEventArgs { Message = msg });
                        }
                    }
                } while (read > 0);
            }
            catch (IOException)
            {
                // suppress all I/O errors
            }
        }
    }
}