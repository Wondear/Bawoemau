using System;
using System.Net;
using System.Net.Sockets;
using System.Text;

public class SimpleSocketServer
{
    public static void Main()
    {
        StartServer();
    }

    private static void StartServer()
    {
        try
        {
            // 서버 소켓 생성
            TcpListener serverSocket = new TcpListener(IPAddress.Any, 8080);
            serverSocket.Start();
            Console.WriteLine("Server Started");

            while (true)
            {
                // 클라이언트 연결 대기
                TcpClient clientSocket = serverSocket.AcceptTcpClient();
                Console.WriteLine("Client Connected");

                // 클라이언트와 통신을 위한 NetworkStream 생성
                NetworkStream networkStream = clientSocket.GetStream();
                byte[] bytesFrom = new byte[256];
                int bytesRead = networkStream.Read(bytesFrom, 0, bytesFrom.Length);
                string dataFromClient = Encoding.ASCII.GetString(bytesFrom, 0, bytesRead);
                Console.WriteLine("Received from client: " + dataFromClient);

                // 받은 메시지를 클라이언트에게 다시 전송
                byte[] sendBytes = Encoding.ASCII.GetBytes(dataFromClient);
                networkStream.Write(sendBytes, 0, sendBytes.Length);
                networkStream.Flush();
                Console.WriteLine("Sent to client: " + dataFromClient);

                // 연결 종료
                networkStream.Close();
                clientSocket.Close();
                Console.WriteLine("Client Disconnected");
            }
        }
        catch (Exception e)
        {
            Console.WriteLine("Exception: " + e.Message);
        }
    }
}
