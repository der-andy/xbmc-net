using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using XbmcNet.External.ReSharperAnnotations;
using XbmcNet.Namespaces;
using XbmcNet.Schema;

namespace XbmcNet
{
    /// <summary>
    ///     Represents a connection to an XBMC server.
    /// </summary>
    [PublicAPI]
    public class XbmcConnection : IDisposable
    {
        private readonly TcpClient _client;
        private static readonly Encoding ConnectionEncoding = Encoding.UTF8;

        private readonly Dictionary<string, ManualResetEventSlim> _events =
            new Dictionary<string, ManualResetEventSlim>();

        private readonly object _messageReceivedLock = new object();
        private readonly Dictionary<string, JObject> _responses = new Dictionary<string, JObject>();
        private string _messageBuffer = "";
        private TcpReader _reader;

        /// <summary>
        ///     Initiates a new connection to an XBMC server.
        /// </summary>
        /// <param name="host">The host name or IP address to connect to.</param>
        /// <param name="port">The port number to connect to.</param>
        public XbmcConnection(string host, int port)
        {
            Host = host;
            Port = port;

            Player = new Player(this);
            VideoLibrary = new VideoLibrary(this);

            _client = new TcpClient();

            Connect();
        }

        /// <summary>
        ///     Returns the host name this connection is bound to.
        /// </summary>
        [PublicAPI]
        public string Host { get; private set; }

        /// <summary>
        ///     Returns the port number this connection is bound to.
        /// </summary>
        [PublicAPI]
        public int Port { get; private set; }

        #region Namespaces

        /// <summary>
        ///     Provides access to the functions of the XBMC Player namespace.
        /// </summary>
        [PublicAPI]
        public Player Player { get; private set; }

        /// <summary>
        ///     Provides access to the functions of the XBMC VideoLibrary namespace.
        /// </summary>
        [PublicAPI]
        public VideoLibrary VideoLibrary { get; private set; }

        #endregion

        /// <summary>
        ///     Tries to establish a connection to the XBMC server.
        /// </summary>
        /// <exception cref="XbmcNetException">Thrown if a connection could not be established.</exception>
        private void Connect()
        {
            try
            {
                _client.Connect(Host, Port);
                _reader = new TcpReader(_client.GetStream(), ConnectionEncoding);
                _reader.MessageReceived += OnMessageReceived;
                _reader.Start();
            }
            catch (Exception e)
            {
                throw new XbmcNetException("Could not connect to XBMC server!", e);
            }
        }

        private void OnMessageReceived(object sender, MessageReceivedEventArgs args)
        {
            lock (_messageReceivedLock)
            {
                _messageBuffer += args.Message;
                int count;

                do
                {
                    // cut buffer into JSON objects
                    int i = 0;
                    count = 0;
                    bool quote = false, escape = false;
                    while ((i < _messageBuffer.Length && count > 0) || i == 0)
                    {
                        if (!quote && _messageBuffer[i] == '{')
                        {
                            count++;
                        }
                        else if (!quote && _messageBuffer[i] == '}')
                        {
                            count--;
                        }

                        else if (!quote && _messageBuffer[i] == '"')
                        {
                            quote = true;
                        }
                        else if (quote && !escape && _messageBuffer[i] == '"')
                        {
                            quote = false;
                        }

                        else if (quote && !escape && _messageBuffer[i] == '\\')
                        {
                            escape = true;
                        }
                        else
                        {
                            escape = false;
                        }
                        i++;
                    }

                    if (count == 0)
                    {
                        ProcessMessage(_messageBuffer.Substring(0, i));
                        _messageBuffer = _messageBuffer.Substring(i);
                    }
                } while (_messageBuffer != "" && count == 0);
            }
        }

        private void ProcessMessage(string msg)
        {
            JObject obj = JObject.Parse(msg);

            var id = (string) obj["id"];

            if (!string.IsNullOrEmpty(id))
            {
                _responses.Add(id, obj);
                _events[id].Set();
            }
            else
            {
                ProcessNotification(obj);
            }
        }

        private void ProcessNotification(JObject jObject)
        {
            // foo
        }

        /// <summary>
        /// Sends a request to the XBMC server and waits for the corresponding response.
        /// </summary>
        /// <typeparam name="T">The type the response will be deserialized to.</typeparam>
        /// <param name="request">The request to send to the server.</param>
        internal async Task<T> SendRequest<T>(RpcRequest request) where T : class
        {
            if (_client == null || !_client.Connected)
            {
                throw new XbmcNetException("Can't send request when not connected!");
            }

            string json = JsonConvert.SerializeObject(request, Formatting.None);
            //Trace.WriteLine(json);
            byte[] bytes = ConnectionEncoding.GetBytes(json);

            _client.GetStream().Write(bytes, 0, bytes.Length);

            var e = new ManualResetEventSlim(false);
            _events.Add(request.Id, e);

            return await Task.Factory.StartNew<T>(WaitForReply<T>, request.Id);
        }

        /// <summary>
        ///     Waits for a response for the request with the specified ID.
        /// </summary>
        private T WaitForReply<T>(object state) where T : class
        {
            var id = (string) state;

            if (!_events.ContainsKey(id))
            {
                return null;
            }

            ManualResetEventSlim e = _events[id];
            e.Wait();

            if (!_responses.ContainsKey(id))
            {
                return null;
            }

            JObject json = _responses[id];
            XbmcResponse<T> response;

            try
            {
                var serializer = new JsonSerializer
                                     {
                                         ConstructorHandling = ConstructorHandling.AllowNonPublicDefaultConstructor
                                     };

                response = json.ToObject<XbmcResponse<T>>(serializer);
            }
            catch
            {
                return null;
            }

            if (response.Error != null)
            {
                throw new XbmcNetException(response.Error.Message, response.Error.Code, response.Error.Data);
            }

            if (response.Id != id)
            {
                throw new XbmcNetException("Response ID mismatch!");
            }

            _responses.Remove(id);
            _events.Remove(id);

            return response.Result;
        }

        public void Dispose()
        {
            if (_client != null)
            {
                _client.Close();
            }
        }
    }
}