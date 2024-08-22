using Domain.Models;
using Microsoft.AspNetCore.SignalR;

namespace Application.Services
{
    public class NotificationHub : Hub
    {
        public async Task SendNotificationToAll(Notification notification)
        {
            await Clients.All.SendAsync("ReceiveNotification", notification);
        }
    }
}