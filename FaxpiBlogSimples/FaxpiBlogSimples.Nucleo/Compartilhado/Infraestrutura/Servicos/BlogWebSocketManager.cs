using System.Net.WebSockets;
using System.Text;

namespace FaxpiBlogSimples.Nucleo.Compartilhado.Infraestrutura.Servicos
{
  public class BlogWebSocketManager
  {
    public BlogWebSocketManager()
    {
    }

    private readonly List<WebSocket> _sockets = [];

    public async Task HandleWebSocketAsync(WebSocket ws)
    {
      _sockets.Add(ws);

      var buffer = new byte[1024];
      WebSocketReceiveResult result = await ws.ReceiveAsync(new ArraySegment<byte>(buffer), CancellationToken.None);

      while (!result.CloseStatus.HasValue)
      {
        var message = Encoding.UTF8.GetString(buffer, 0, result.Count);
        await BroadcastMessageAsync(message);
        result = await ws.ReceiveAsync(new ArraySegment<byte>(buffer), CancellationToken.None);
      }

      _sockets.Remove(ws);
      await ws.CloseAsync(result.CloseStatus.Value, result.CloseStatusDescription, CancellationToken.None);
    }

    public async Task BroadcastMessageAsync(string message)
    {
      var buffer = Encoding.UTF8.GetBytes(message);

      foreach (var socket in _sockets)
      {
        if (socket.State == WebSocketState.Open)
        {
          await socket.SendAsync(new ArraySegment<byte>(buffer, 0, buffer.Length), WebSocketMessageType.Text, true, CancellationToken.None);
        }
      }
    }
  }
}