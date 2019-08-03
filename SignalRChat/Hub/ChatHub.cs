using Microsoft.AspNetCore.SignalR;
using System.Threading.Tasks;

namespace SignalRChat.Hubs
{
    /// <summary>
    /// ��Hub�̳е������������ģ���������ӹ��������� �ͻ��˿��Ե��ö���Ϊpublic�ķ���
    /// </summary>
    public class ChatHub : Hub
    {
        /// <summary>
        /// ����ͻ��˿��Ե��õķ���
        /// </summary>
        /// <param name="user"></param>
        /// <param name="message"></param>
        /// <returns></returns>
        public async Task SendMessage(string user, string message)
        {
            //���ÿͻ������е�ReceiveMessage����
            await Clients.All.SendAsync("ReceiveMessage", user, message);
        }
    }
}