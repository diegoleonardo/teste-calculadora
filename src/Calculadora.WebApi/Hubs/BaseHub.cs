using System.Threading.Tasks;
using Microsoft.AspNetCore.SignalR;

namespace Calculadora.WebApi.Hubs {
    public class BaseHub : Hub {
        public async Task SendMessage (string user, string message) {
            await Clients.All.SendAsync ("ReceiveMessage", user, message);
        }
    }
}