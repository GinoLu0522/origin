using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.WebSockets;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace WebServer
{
  internal class WebSocketServer
  {
    public async Task StartAsync(string uri)
    {
      HttpListener listener = new HttpListener();
      listener.Prefixes.Add(uri);
      listener.Start();
      Console.WriteLine("WebSocket server started.");
//123456
      while (true)
      {
        HttpListenerContext context = await listener.GetContextAsync();
        if (context.Request.IsWebSocketRequest)
        {
          HttpListenerWebSocketContext wsContext = await context.AcceptWebSocketAsync(null);
          Console.WriteLine("Client connected.");
          await HandleClientAsync(wsContext.WebSocket);
        }
        else
        {
          context.Response.StatusCode = 400;
          context.Response.Close();
        }
      }
    }

    private async Task HandleClientAsync(WebSocket webSocket)
    {
      byte[] buffer = new byte[1024];
      while (webSocket.State == WebSocketState.Open)
      {
        WebSocketReceiveResult result = await webSocket.ReceiveAsync(new ArraySegment<byte>(buffer), CancellationToken.None);
        string message = Encoding.UTF8.GetString(buffer, 0, result.Count);
        Console.WriteLine("Received: " + message);

        string response = "Server received: " + message;
        byte[] responseBuffer = Encoding.UTF8.GetBytes(response);
        await webSocket.SendAsync(new ArraySegment<byte>(responseBuffer), WebSocketMessageType.Text, true, CancellationToken.None);
      }
    }
  }
}
