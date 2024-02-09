using System.Text;
using System.Net;
using System.Net.Sockets;

public class Sample1
{
    public static string DoSocketGet(string server)
    {
        // 서버에 기록할 변수와 String을 설정합니다.
        Encoding ASCII = Encoding.ASCII;
        string Get = "GET / HTTP/1.1\r\nHost: " + server +
                     "\r\nConnection: Close\r\n\r\n";
        Byte[] ByteGet = ASCII.GetBytes(Get);
        Byte[] RecvBytes = new Byte[256];
        String strRetPage = null;

        // IP 주소 및 IPEndPoint는 요청을 수신할 엔드포인트를 나타냅니다.
        // Get first IPAddress in list return by DNS.

        try
        {

            // 다음 루프에서 평가할 변수를 정의한 다음 서버에 연결하는 데 사용합니다.
            // 이 변수들은 그 이후에 접근할 수 있도록 for 루프 외부에서 정의됩니다.
            Socket s = null;
            IPEndPoint hostEndPoint;
            IPAddress hostAddress = null;
            int conPort = 80;

            // Get DNS host information.
            IPHostEntry hostInfo = Dns.GetHostEntry(server);
            // Get the DNS IP addresses associated with the host.
            IPAddress[] IPaddresses = hostInfo.AddressList;

            // 소켓 및 수신 호스트 IP 주소 및 IPEndPoint를 평가합니다.
            for (int index = 0; index < IPaddresses.Length; index++)
            {
                hostAddress = IPaddresses[index];
                hostEndPoint = new IPEndPoint(hostAddress, conPort);


                // TCP 연결을 통해 데이터를 전송하는 소켓을 만듭니다.
                // 지정된 소켓 종류 및 프로토콜을 사용하여 Socket 클래스의 새 인스턴스를 초기화합니다.
                // 운영 체제에서 IPv6을 지원하는 경우 이 생성자는 이중 모드 소켓을 만듭니다.
                // 그렇지 않으면 IPv4 소켓을 만듭니다.
                s = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);


                // 해당 IPEndPoint를 사용하여 호스트에 연결합니다.
                s.Connect(hostEndPoint);

                if (!s.Connected)
                {
                    // Connection failed, try next IPaddress.
                    strRetPage = "Unable to connect to host";
                    s = null;
                    continue;
                }

                // Sent the GET request to the host.
                s.Send(ByteGet, ByteGet.Length, 0);

            } // End of the for loop.


            // Receive the host home page content and loop until all the data is received.
            Int32 bytes = s.Receive(RecvBytes, RecvBytes.Length, 0);
            strRetPage = "Default HTML page on " + server + ":\r\n";
            strRetPage = strRetPage + ASCII.GetString(RecvBytes, 0, bytes);

            while (bytes > 0)
            {
                bytes = s.Receive(RecvBytes, RecvBytes.Length, 0);
                strRetPage = strRetPage + ASCII.GetString(RecvBytes, 0, bytes);
            }

        } // End of the try block.

        // handle이 소켓이 아니거나 소켓 정보에 액세스할 수 없습니다.
        catch (SocketException e)
        {
            Console.WriteLine("SocketException caught!!!");
            Console.WriteLine("Source : " + e.Source);
            Console.WriteLine("Message : " + e.Message);
        }
        // handle이(가) null인 경우
        catch (ArgumentNullException e)
        {
            Console.WriteLine("ArgumentNullException caught!!!");
            Console.WriteLine("Source : " + e.Source);
            Console.WriteLine("Message : " + e.Message);
        }
        catch (NullReferenceException e)
        {
            Console.WriteLine("NullReferenceException caught!!!");
            Console.WriteLine("Source : " + e.Source);
            Console.WriteLine("Message : " + e.Message);
        }
        catch (Exception e)
        {
            Console.WriteLine("Exception caught!!!");
            Console.WriteLine("Source : " + e.Source);
            Console.WriteLine("Message : " + e.Message);
        }

        return strRetPage;
    }

    public static void Main()
    {
        Console.WriteLine(DoSocketGet("localhost"));
    }
}