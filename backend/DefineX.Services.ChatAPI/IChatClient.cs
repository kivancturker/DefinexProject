namespace DefineX.Services.ChatAPI;

public interface IChatClient
{
    Task ReceiveMessage(string message);
}