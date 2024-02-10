namespace Bawoemau.library.Socket
{
    internal class Socket
    {
        private readonly int _port;
        private readonly SocketStateManager _socketStateManager;
        private readonly SocketMessageManager _socketMessageManager;

        public SingleSocket(int port)
        {
            _port = port;
        }

        public ISocket SocketServer => new SocketServer();

        public ISocket SocketClient => new SocketClient();
    }
}
