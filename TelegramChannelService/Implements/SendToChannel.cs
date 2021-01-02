using System;
using System.Net;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using TelegramChannelService.Interfaces;
using TelegramChannelService.Models;

namespace TelegramChannelService.Implements
{
    public class SendToChannel : ISendToChannel
    {
        private string _botToken;
        private const string TELEGRAM_BOT_API = "https://api.telegram.org/bot";
        public void Init(string botToken)
        {
            _botToken = botToken;
        }

        public async Task<Response> SendTextMessage(string botToken, string msg, string sendTo, bool hasWebPreview = false, CancellationToken ct = default)
        {
            Init(botToken);
            return await SendTextMessage(msg, sendTo, hasWebPreview, ct);
        }
        public async Task<Response> SendTextMessage(string msg, string sendTo, bool hasWebPreview = false, CancellationToken ct = default)
        {
            if (string.IsNullOrWhiteSpace(_botToken))
            {
                throw new ArgumentNullException(nameof(_botToken), "You should fill botToken via `Init` or use another overload");
            }

            var response = new Response();
            try
            {
                msg = WebUtility.UrlEncode(msg);

                using (var httpClient = new HttpClient())
                {
                    var res = await httpClient.GetAsync($"{TELEGRAM_BOT_API}{_botToken}/sendMessage?chat_id={sendTo}&text={msg}&parse_mode=HTML&disable_web_page_preview={hasWebPreview}", ct);
                    if (res.StatusCode != HttpStatusCode.OK)
                    {
                        response.Message = await res.Content.ReadAsStringAsync();
                    }
                    else
                    {
                        response.IsSuccess = true;
                    }
                }
            }
            catch (Exception ex)
            {
                response.Exception = ex;
            }
            return response;
        }
    }
}
