using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.WebSockets;
using System.Text;
using System.Threading.Tasks;

namespace WebServer
{
  internal class WebSocketClient
  {
    public async Task StartAsync(string uri)
    {
      using (ClientWebSocket webSocket = new ClientWebSocket())
      {
        await webSocket.ConnectAsync(new Uri(uri), CancellationToken.None);
        Console.WriteLine("Connected to server.");

        // 發送訊息
        string message = "Hello from client";
        byte[] buffer = Encoding.UTF8.GetBytes(message);
        await webSocket.SendAsync(new ArraySegment<byte>(buffer), WebSocketMessageType.Text, true, CancellationToken.None);
        Console.WriteLine("Sent: " + message);

        // 接收訊息
        buffer = new byte[1024];
        WebSocketReceiveResult result = await webSocket.ReceiveAsync(new ArraySegment<byte>(buffer), CancellationToken.None);
        string response = Encoding.UTF8.GetString(buffer, 0, result.Count);
        Console.WriteLine("Received: " + response);
      }
    }
  }
}
