using System.Net.WebSockets;
using System.Text;

namespace WebServer
{
  public partial class Form1 : Form
  {
    public Form1()
    {
      InitializeComponent();
    }

    private async void button1_Click(object sender, EventArgs e)
    {
      //WebSocketClient client = new WebSocketClient();
      //await client.StartAsync("ws://localhost:8080/");

     await StartAsync("ws://localhost:8080/");
    }

    public async Task StartAsync(string uri)
    {
      ClientWebSocket clientWebSocket = new ClientWebSocket();
      await clientWebSocket.ConnectAsync(new Uri(uri), CancellationToken.None);

      label1.Text="Connected to the server. Start sending messages...";

      // Send messages to the server
      string message = textBox1.Text;
      byte[] buffer = Encoding.UTF8.GetBytes(message);
      await clientWebSocket.SendAsync(new ArraySegment<byte>(buffer), WebSocketMessageType.Text, true, CancellationToken.None);

      // Receive messages from the server
      byte[] receiveBuffer = new byte[1024];
      while (clientWebSocket.State == WebSocketState.Open)
      {
        WebSocketReceiveResult result = await clientWebSocket.ReceiveAsync(new ArraySegment<byte>(receiveBuffer), CancellationToken.None);
        if (result.MessageType == WebSocketMessageType.Text)
        {
          string receivedMessage = Encoding.UTF8.GetString(receiveBuffer, 0, result.Count);
          label1.Text = $"Received message from server: {receivedMessage}";
          textBox2.Text = textBox2.Text + "\r\n" + receivedMessage;
        }

        await clientWebSocket.CloseAsync(WebSocketCloseStatus.NormalClosure,"close",CancellationToken.None);
      }

      
    }
  }
}

