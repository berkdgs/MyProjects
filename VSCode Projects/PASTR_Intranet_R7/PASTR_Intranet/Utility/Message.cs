using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PASTR.Intranet.Utility
{
    public enum MessageType
    {
        Success = 1,
        Warning = 2,
        Danger = 3
    }
    public class Message
    {
        public const String MessageName = "Message";
        public String Text { get; set; }
        public Int32? Duration { get; set; }
        public Boolean Closeable { get; set; }
        public MessageType Type { get; set; }
    }
}