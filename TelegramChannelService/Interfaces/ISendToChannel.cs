using System.Threading;
using System.Threading.Tasks;
using TelegramChannelService.Models;

namespace TelegramChannelService.Interfaces
{
    public interface ISendToChannel
    {

        /// <summary>
        /// </summary>
        /// <param name="botToken">Bot Token</param>
        void Init(string botToken);

        /// <summary>
        /// Send Text Message To Channel, insert your botToken directly to method
        /// </summary>
        /// <param name="botToken">Bot Token</param>
        /// <param name="msg">Text Message</param>
        /// <param name="sendTo">Channel User With @  - For example @mychannel</param>
        /// <param name="hasWebPreview">Html can preview if possible</param>
        /// <param name="ct">Cancellation Token</param>
        /// <returns>Response</returns>
        Task<Response> SendTextMessage(string botToken, string msg, string sendTo, bool hasWebPreview = false, CancellationToken ct = default);

        /// <summary>
        /// Send Text Message To Channel, ** Use "Init(yourBotToken)" before use this method
        /// Or you will get exception
        /// </summary>
        /// <param name="msg">Text Messsage</param>
        /// <param name="sendTo">Channel User With @  - For example @mychannel</param>
        /// <param name="hasWebPreview">Html can preview if possible</param>
        /// <param name="ct">Cancellation Token</param>
        /// <returns></returns>
        Task<Response> SendTextMessage(string msg, string sendTo, bool hasWebPreview = false, CancellationToken ct = default);
    }
}
