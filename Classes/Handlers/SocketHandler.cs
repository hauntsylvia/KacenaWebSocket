using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace KacenaWebSocket.Classes.Handlers
{
    public class SocketHandler
    {
        private readonly TcpListener listener;
        public TcpListener Listener => listener;
        public SocketHandler(TcpListener Listener)
        {
            this.listener = Listener;
        }
        private async Task ProcessRequest(TcpClient Client)
        {
            string? Data = null;
            using(NetworkStream Stream = Client.GetStream())
                if(Stream.CanRead)
                    using(StreamReader Reader = new(Stream))
                        Data = await Reader.ReadToEndAsync();
            if(Data != null)
            {

            }
        }
        public void StartListening()
        {
            this.Listener.Start();
            new Task(async () =>
            {
                while (true)
                {
                    TcpClient Client = await this.Listener.AcceptTcpClientAsync();
                    await this.ProcessRequest(Client);
                }
            }).Start();
        }
    }
}
