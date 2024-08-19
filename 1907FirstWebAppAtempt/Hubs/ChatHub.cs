using Microsoft.AspNetCore.SignalR;

namespace _1907FirstWebAppAtempt.Hubs
{
    public class ChatHub : Hub
    {
        public async Task MessageAll(string sender, string message)
        {
            await Clients.All.SendAsync("NewMessage", sender, message);
        }
    }
}
