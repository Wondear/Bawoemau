using System.Text;
using System.Net.Sockets;

public class Sample2
{
    private static void SendHttpRequest(Uri? uri = null, int port = 80)
    {
        uri ??= new Uri("http://example.com");

        // Construct a minimalistic HTTP/1.1 request
        byte[] requestBytes = Encoding.ASCII.GetBytes(@$"GET {uri.AbsoluteUri} HTTP/1.0
Host: {uri.Host}
Connection: Close

");

        // Create and connect a dual-stack socket
        using Socket socket = new Socket(SocketType.Stream, ProtocolType.Tcp);
        socket.Connect(uri.Host, port);

        // Send the request.
        // 이 예에서 적은 양의 데이터의 경우 Send()에 대한 첫 번째 호출이 버퍼를 완전히 전달할 가능성이 높지만
        // 더 큰 실제 버퍼의 경우에는 이러한 일이 발생하는 것이 보장되지 않습니다.
        // 가장 좋은 방법은 모든 데이터가 전송될 때까지 반복하는 것입니다.
        int bytesSent = 0;
        while (bytesSent < requestBytes.Length)
        {
            bytesSent += socket.Send(requestBytes, bytesSent, requestBytes.Length - bytesSent, SocketFlags.None);
        }

        // Do minimalistic buffering assuming ASCII response
        byte[] responseBytes = new byte[256];
        char[] responseChars = new char[256];

        while (true)
        {
            int bytesReceived = socket.Receive(responseBytes);

            // Receiving 0 bytes means EOF(End-of-file) has been reached
            if (bytesReceived == 0) break;

            // Convert byteCount bytes to ASCII characters using the 'responseChars' buffer as destination
            int charCount = Encoding.ASCII.GetChars(responseBytes, 0, bytesReceived, responseChars, 0);

            // Print the contents of the 'responseChars' buffer to Console.Out
            Console.Out.Write(responseChars, 0, charCount);
        }
    }

    private static async Task SendHttpRequestAsync(Uri? uri = null, int port = 80, CancellationToken cancellationToken = default)
    {
        uri ??= new Uri("http://example.com");

        // Construct a minimalistic HTTP/1.1 request
        byte[] requestBytes = Encoding.ASCII.GetBytes(@$"GET {uri.AbsoluteUri} HTTP/1.1
Host: {uri.Host}
Connection: Close

");

        // Create and connect a dual-stack socket
        using Socket socket = new Socket(SocketType.Stream, ProtocolType.Tcp);
        await socket.ConnectAsync(uri.Host, port, cancellationToken);

        // Send the request.
        // For the tiny amount of data in this example, the first call to SendAsync() will likely deliver the buffer completely,
        // however this is not guaranteed to happen for larger real-life buffers.
        // The best practice is to iterate until all the data is sent.
        int bytesSent = 0;
        while (bytesSent < requestBytes.Length)
        {
            bytesSent += await socket.SendAsync(requestBytes.AsMemory(bytesSent), SocketFlags.None);
        }

        // Do minimalistic buffering assuming ASCII response
        byte[] responseBytes = new byte[256];
        char[] responseChars = new char[256];

        while (true)
        {
            int bytesReceived = await socket.ReceiveAsync(responseBytes, SocketFlags.None, cancellationToken);

            // Receiving 0 bytes means EOF has been reached
            if (bytesReceived == 0) break;

            // Convert byteCount bytes to ASCII characters using the 'responseChars' buffer as destination
            int charCount = Encoding.ASCII.GetChars(responseBytes, 0, bytesReceived, responseChars, 0);

            // Print the contents of the 'responseChars' buffer to Console.Out
            await Console.Out.WriteAsync(responseChars.AsMemory(0, charCount), cancellationToken);
        }
    }
}