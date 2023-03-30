using Microsoft.AspNetCore.SignalR;

namespace SignalR.SignalR
{
    public class ClaseSignalR: Hub
    {
        public async Task JoinRoom(string room)
        {
            await Groups.AddToGroupAsync(Context.ConnectionId, room);
            await Clients.Group(room).SendAsync("user joined");
        }

        public async Task SendMessage(string room, string user, string message)
        {
            if (room == null)
            {
                await Clients.All.SendAsync("new message");
                await Clients.All.SendAsync("new notification");
            }
            else
            {
                await Clients.Group(room).SendAsync("new message", user, message);
                await Clients.All.SendAsync("new notification", user, message);
            }
        }
        public async Task SendEvent(string message)
        {
            if (message == null)
            {
                await Clients.All.SendAsync("new event");
            }
            else
            {
                await Clients.All.SendAsync("new event", message);
            }
        }
    }
}
