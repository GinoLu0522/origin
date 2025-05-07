using System.Net.Sockets;
using System.Net;
using System.Net.WebSockets;
using System.Text;

namespace WebServer
{
  public partial class Form1 : Form
  {
    public Form1()
    {
      InitializeComponent();
            //1233344
    }

    private async void button1_Click(object sender, EventArgs e)
    {
      //WebSocketServer server = new WebSocketServer();
      await StartServer("localhost",8080);
    }

    private void button2_Click(object sender, EventArgs e)
    {
      var host = Dns.GetHostEntry(Dns.GetHostName());
      foreach (var ip in host.AddressList)
      {
        if (ip.AddressFamily == AddressFamily.InterNetwork)
        {
          label1.Text = ip.ToString();
        }
      }
      //throw new Exception("No network adapters with an IPv4 address in the system!");
    }


    public async Task StartServer(string ipAddress, int port)
    {
      HttpListener listener = new HttpListener();
      button1.Enabled = false; button2.Enabled = false;
      listener.Prefixes.Add($"http://{ipAddress}:{port}/");
      listener.Start();

      label1.Text = "Server started. Waiting for connections...";

      while (true)
      {
        HttpListenerContext context = await listener.GetContextAsync();
        if (context.Request.IsWebSocketRequest)
        {
          await ProcessWebSocketRequest(context);
        }
        else
        {
          context.Response.StatusCode = 400;
          context.Response.Close();
        }
      }
    }

    private async Task ProcessWebSocketRequest(HttpListenerContext context)
    {
      HttpListenerWebSocketContext webSocketContext = await context.AcceptWebSocketAsync(null);
      WebSocket socket = webSocketContext.WebSocket;



      // Handle incoming messages
      byte[] buffer = new byte[1024];
      while (socket.State == WebSocketState.Open)
      {
        WebSocketReceiveResult result = await socket.ReceiveAsync(new ArraySegment<byte>(buffer), CancellationToken.None);
        if (result.MessageType == WebSocketMessageType.Text)
        {
          string receivedMessage = System.Text.Encoding.UTF8.GetString(buffer, 0, result.Count);
          label1.Text = $"Received message: {receivedMessage}";

          textBox1.Text = textBox1.Text + "\r\n" + receivedMessage;

          // Echo back the received message'

          await socket.SendAsync(new ArraySegment<byte>(buffer, 0, result.Count), WebSocketMessageType.Text, true, CancellationToken.None);
        }
        else if (result.MessageType == WebSocketMessageType.Close)
        {
          await socket.CloseAsync(WebSocketCloseStatus.NormalClosure, "Close", CancellationToken.None);
        }
      }
    }
  }
}
