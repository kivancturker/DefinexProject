using Microsoft.AspNetCore.SignalR;

namespace DefineX.Services.ChatAPI;

public sealed class ChatHub : Hub<IChatClient>
{
    public override async Task OnConnectedAsync()
    {
        await Clients.All.ReceiveMessage($"{Context.ConnectionId} has joined the chat");
    }

    public async Task SendMessage(string message, string userRole)
    {
        await Clients.All.ReceiveMessage($"{userRole}: {message}");
    }
}