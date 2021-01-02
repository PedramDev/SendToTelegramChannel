using System;

namespace TelegramChannelService.Models
{
    public class Response
    {
        public bool IsSuccess { get; set; }
        public Exception Exception { get; set; }
        public string Message { get; set; }
    }
}
