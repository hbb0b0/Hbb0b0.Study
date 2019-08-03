using Microsoft.AspNetCore.SignalR;
using System.Threading.Tasks;

namespace SignalRChat.Hubs
{
    /// <summary>
    /// 从Hub继承的类来创建中心，并向其添加公共方法。 客户端可以调用定义为public的方法
    /// </summary>
    public class ChatHub : Hub
    {
        /// <summary>
        /// 定义客户端可以调用的方法
        /// </summary>
        /// <param name="user"></param>
        /// <param name="message"></param>
        /// <returns></returns>
        public async Task SendMessage(string user, string message)
        {
            //调用客户端所有的ReceiveMessage方法
            await Clients.All.SendAsync("ReceiveMessage", user, message);
        }
    }
}